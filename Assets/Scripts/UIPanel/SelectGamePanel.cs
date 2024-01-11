using UnityEngine;
using System;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace ProjectBase.UI
{
	public class SelectGamePanelData : IData
	{

	}

	public partial class SelectGamePanel : UIController
	{
		public Button[] btns;
		const string TrainScene = "FirstTrain";

		private void Awake()
		{
			for (int i = 0; i < btns.Length; i++)
			{
				int index = i;
				btns[i].onClick.AddListener(() =>
				{
					Debug.Log($"{nameof(SelectGamePanel)} Select {index}");
					UIKit.CloseLast();
					UniTask.Void(async () =>
					{
						await UIKit.OpenAwait<GamePanel>();
						await SceneManager.LoadSceneAsync(TrainScene);
						UIKit.Get<BottomPanel>().ShowBackground = false;
					});
				});
			}
		}
	}
}
