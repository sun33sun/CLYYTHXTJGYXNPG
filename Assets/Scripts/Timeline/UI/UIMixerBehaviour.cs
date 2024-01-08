using Cysharp.Threading.Tasks;
using ProjectBase.UI;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectBase.Timeline
{
	public enum E_UIFunction
	{
		None = 0,
		OpenEye,
		CloseEye,
		ChangeTip,
		WaitExamine,
		AwaitPop,
	}

	public class UIMixerBehaviour : PlayableBehaviour
	{
		public List<double> timeList = new List<double>();
		List<UIBehaviour> behaviours = new List<UIBehaviour>();
		private PlayableDirector director;

		GamePanel gamePanel = null;
		TopPanel topPanel = null;
		BottomPanel bottomPanel = null;

		CancellationTokenSource cts = new CancellationTokenSource();

		public override void OnPlayableCreate(Playable playable)
		{
			director = (playable.GetGraph().GetResolver() as PlayableDirector);

			if (!Application.isPlaying)
				return;

			gamePanel = UIKit.Get<GamePanel>();
			topPanel = UIKit.Get<TopPanel>();
			bottomPanel = UIKit.Get<BottomPanel>();
		}

		public override void ProcessFrame(Playable playable, FrameData info, object playerData)
		{
			if (!Application.isPlaying || cts.Token.IsCancellationRequested)
				return;

			UIBehaviour behaviour = null;

			if (behaviours.Count < 1)
			{
				int inputCount = playable.GetInputCount();
				for (int i = 0; i < inputCount; i++)
				{
					ScriptPlayable<UIBehaviour> input = (ScriptPlayable<UIBehaviour>)playable.GetInput(i);
					behaviour = input.GetBehaviour();
					behaviours.Add(behaviour);
				}
			}

			for (int i = 0; i < behaviours.Count; i++)
			{
				behaviour = behaviours[i];
				if (director.time < timeList[i])
				{
					behaviour.IsUsed = false;
					continue;
				}
				if (behaviour.IsUsed)
					continue;
				behaviour.IsUsed = true;

				ExecuteFunction(behaviour);
			}
		}

		void ExecuteFunction(UIBehaviour behaviour)
		{
			switch (behaviour.functionEnum)
			{
				case E_UIFunction.OpenEye:
					bottomPanel.ShowBackground = false;
					break;
				case E_UIFunction.CloseEye:
					bottomPanel.ShowBackground = true;
					break;
				case E_UIFunction.ChangeTip:
					gamePanel.ChangeTip(behaviour.newTip);
					break;
				case E_UIFunction.WaitExamine:
					WaitExamine(behaviour);
					break;
				case E_UIFunction.AwaitPop:
					AwaitPop(behaviour);
					break;
			}
		}

		/// <summary>
		/// 等待答题
		/// </summary>
		/// <param name="behaviour"></param>
		void WaitExamine(UIBehaviour behaviour)
		{
			UniTask.Void(async () =>
			{
				director.Pause();
				await gamePanel.WaitExamine(behaviour.newTip, cts.Token);
				director.Resume();
			});
		}

		/// <summary>
		/// 等待弹窗
		/// </summary>
		/// <param name="behaviour"></param>
		void AwaitPop(UIBehaviour behaviour)
		{
			UniTask.Void(async () =>
			{
				director.Pause();
				await topPanel.AwaitPop(behaviour.newPop, cts.Token);
				director.Resume();
			});
		}

		public override void OnPlayableDestroy(Playable playable)
		{
			cts.Cancel();
			base.OnPlayableDestroy(playable);
		}
	}
}

