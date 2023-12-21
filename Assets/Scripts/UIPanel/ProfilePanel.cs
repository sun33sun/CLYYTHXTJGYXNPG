
using UnityEngine;
using System;
using UnityEngine.UI;

namespace ProjectBase.UI
{
	public class ProfilePanelData : IData
	{

	}
	public partial class ProfilePanel : UIController
	{
		[SerializeField] Toggle[] togs;
		[SerializeField] GameObject[] objs;

		private void Awake()
		{
        }
	}
}
