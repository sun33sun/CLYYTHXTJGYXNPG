using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace ProjectBase.Timeline
{
	[Serializable]
	public class UIBehaviour : PlayableBehaviour
	{
		[HideInInspector] public bool IsUsed;
		public E_UIFunction functionEnum;

#if UNITY_EDITOR
		[ShowIf(nameof(functionEnum),E_UIFunction.ChangeTip)] public string newTip = string.Empty;
		[ShowIf(nameof(functionEnum), E_UIFunction.WaitExamine)] public string newExamine = string.Empty;
		[ShowIf(nameof(functionEnum), E_UIFunction.AwaitPop)] public string newPop = string.Empty;
#endif
	}
}

