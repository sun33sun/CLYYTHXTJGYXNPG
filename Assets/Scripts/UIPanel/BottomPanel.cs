using UnityEngine;
using System;

namespace ProjectBase.UI
{
	public class BottomPanelData : IData
	{

	}
	public partial class BottomPanel : UIController
	{
		private void Awake()
		{
			btnScreen.OnPointerDownEvent(p => Screen.fullScreen = !Screen.fullScreen);

		}
	}
}
