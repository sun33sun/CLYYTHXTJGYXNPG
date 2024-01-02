using UnityEngine;
using System;
namespace ProjectBase.UI
{
	public partial class ObjTip : BaseController
	{
		private void Awake()
		{
			Vector2 showPos = imgBk.anchoredPosition;
			btnSwitch.onClick.AddListener(() =>
			{
				if (imgBk.anchoredPosition == showPos)
					imgBk.anchoredPosition = new Vector2(showPos.x - imgBk.sizeDelta.x, showPos.y);
				else
					imgBk.anchoredPosition = showPos;
			});
		}

		public void ChangeTip(string newContent)
		{
			tmpContent.text = newContent;
		}
	}
}
