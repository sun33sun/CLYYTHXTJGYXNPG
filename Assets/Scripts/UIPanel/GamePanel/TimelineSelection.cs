using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;

namespace ProjectBase.UI
{
	public partial class TimelineSelection : BaseController
	{
		public Toggle[] togs;

		[NonSerialized] public AsyncReactiveProperty<int> nowTogId = new AsyncReactiveProperty<int>(0);

		private void Awake()
		{
			Vector2 showPos = imgBk.anchoredPosition;
			btnSwitch.onClick.AddListener(() =>
			{
				if (imgBk.anchoredPosition == showPos)
					imgBk.anchoredPosition = new Vector2(showPos.x + imgBk.sizeDelta.x, showPos.y);
				else
					imgBk.anchoredPosition = showPos;
			});

			for (int i = 0; i < togs.Length; i++)
			{
				int index = i;
				togs[i].onValueChanged.AddListener(isOn => nowTogId.Value = index);
			}
		}
	}
}
