using UnityEngine;
using System;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace ProjectBase.UI
{
	public partial class ModelSelection : BaseController
	{
		[SerializeField] Toggle[] togs;
		[HideInInspector] public AsyncReactiveProperty<int> modelId = new AsyncReactiveProperty<int>(0);

		private void Awake()
		{
			Vector2 hidePos = imgBk.anchoredPosition;
			btnSwitch.onClick.AddListener(() =>
			{
				if (imgBk.anchoredPosition == hidePos)
				{
					imgBk.anchoredPosition = imgBk.anchoredPosition + new Vector2(imgBk.sizeDelta.x, 0);
				}
				else
				{
					imgBk.anchoredPosition = hidePos;
				}
			});

			//Toggle事件
			for (int i = 0; i < togs.Length; i++)
			{
				int index = i;
				togs[i].onValueChanged.AddListener(isOn =>
				{
					if (isOn)
						modelId.Value = index;
				});
			}
		}

	}
}
