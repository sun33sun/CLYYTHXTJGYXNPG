using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace ProjectBase.Timeline
{
	[Serializable]
	public class HighlightClickClip : PlayableAsset, ITimelineClipAsset
	{
		public HighlightClickBehaviour template = new HighlightClickBehaviour();
		public ClipCaps clipCaps => ClipCaps.None;


		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<HighlightClickBehaviour>.Create(graph, template);
			return playable;
		}
	}
}

