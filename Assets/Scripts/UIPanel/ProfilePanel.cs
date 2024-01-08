
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
			for (int i = 0; i < togs.Length; i++)
			{
				int index = i;
				togs[i].onValueChanged.AddListener(isOn =>
				{
					objs[index].gameObject.SetActive(isOn);
				});
			}
		}
	}
}
