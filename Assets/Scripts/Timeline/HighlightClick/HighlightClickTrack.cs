using ProjectBase.Extension;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace ProjectBase.Timeline
{
	[TrackColor(0, 1, 0)]
	[TrackClipType(typeof(HighlightClickClip))]
	public class HighlightClickTrack : TrackAsset
	{
		public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
		{
			var scriptPlayable = ScriptPlayable<HighlightMixerBehaviour>.Create(graph, inputCount);

			HighlightMixerBehaviour b = scriptPlayable.GetBehaviour();

			foreach (var item in GetClips())
			{
				item.displayName = ((int)(item.start * 60)).ToString();
				item.duration = ProjectBaseSettings.Frame5;
				b.timeList.Add(new KeyValuePair<double, double>(item.start, item.end));
			}

			return scriptPlayable;
		}
	}
}

