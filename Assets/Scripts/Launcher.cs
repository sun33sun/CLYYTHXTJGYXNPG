using ProjectBase.UI;
using UnityEngine;

namespace ProjectBase
{
	/// <summary>
	/// 初始化管理器
	/// </summary>
	public class Launcher : MonoBehaviour
	{
		private void Start()
		{
			UIKit.UnRecordOpen<TopPanel>(99);
			UIKit.UnRecordOpen<BottomPanel>(-1);
			UIKit.Open<MainPanel>();
		}
	}
}

