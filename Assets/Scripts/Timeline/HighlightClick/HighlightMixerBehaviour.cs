using Cysharp.Threading.Tasks;
using HighlightPlus;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectBase.Timeline
{
	public class HighlightMixerBehaviour : PlayableBehaviour
	{
		public List<KeyValuePair<double, double>> timeList = new List<KeyValuePair<double, double>>();
		List<HighlightClickBehaviour> behaviours = new List<HighlightClickBehaviour>();
		private PlayableDirector director;

		CancellationTokenSource cts = new CancellationTokenSource();

		public override void OnPlayableCreate(Playable playable)
		{
			cts.Dispose();
			cts = new CancellationTokenSource();
			director = (playable.GetGraph().GetResolver() as PlayableDirector);
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			if (!Application.isPlaying || cts.Token.IsCancellationRequested)
			{
				return;
			}

			if (behaviours.Count < 1)
			{
				int inputCount = playable.GetInputCount();
				for (int i = 0; i < inputCount; i++)
				{
					ScriptPlayable<HighlightClickBehaviour> input = (ScriptPlayable<HighlightClickBehaviour>)playable.GetInput(i);
					behaviours.Add(input.GetBehaviour());
				}
			}

			int behaviourCount = behaviours.Count;
			HighlightClickBehaviour behaviour = null;
			for (int i = 0; i < behaviourCount; i++)
			{
				behaviour = behaviours[i];
				//是否需要重置时间
				if (director.time < timeList[i].Key)
					behaviour.IsUsed = false;
				//是否可以执行
				if (director.time < timeList[i].Value || behaviour.IsUsed)
					continue;
				//执行
				behaviour.IsUsed = true;
				director.Pause();
				WaitHighlightClick(behaviour);
			}
		}

		void WaitHighlightClick(HighlightClickBehaviour behaviour)
		{
			UniTask.Void(async () =>
			{
				if (cts.IsCancellationRequested) return;
				behaviour.collider.enabled = true;
				if (cts.IsCancellationRequested) return;
				behaviour.collider.enabled = false;
				director.Resume();
			});
		}

		public override void OnPlayableDestroy(Playable playable)
		{
			cts.Cancel();
			foreach (var item in behaviours)
			{
				if (item.collider != null)
				{
					HighlightEffect effect = item.collider.gameObject.GetComponent<HighlightEffect>();
					if (effect != null)
						effect.highlighted = false;
				}
			}
			base.OnPlayableDestroy(playable);
		}
	}
}