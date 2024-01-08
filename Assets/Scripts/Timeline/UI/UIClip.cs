using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace ProjectBase.Timeline
{
	[Serializable]
	public class UIClip : PlayableAsset, ITimelineClipAsset
	{
		public UIBehaviour template = new UIBehaviour();
		public ClipCaps clipCaps => ClipCaps.None;

		public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<UIBehaviour>.Create(graph, template);
			return playable;
		}
	}
}

