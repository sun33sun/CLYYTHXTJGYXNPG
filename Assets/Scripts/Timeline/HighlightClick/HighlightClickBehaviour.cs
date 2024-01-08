using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace ProjectBase.Timeline
{
	[Serializable]
	public class HighlightClickBehaviour : PlayableBehaviour
	{
		[HideInInspector] public Collider collider;
		[HideInInspector] public bool IsUsed = false;

		public ExposedReference<Collider> newCollider;

		public override void OnGraphStart(Playable playable)
		{
			collider = newCollider.Resolve(playable.GetGraph().GetResolver());
			base.OnGraphStart(playable);
		}
	}
}

