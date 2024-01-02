
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using ProjectBase.Game;

namespace ProjectBase.UI
{
	public class MainPanelData : UIData
	{

	}
	public partial class MainPanel : UIController
	{
		const string TrainSceneName = "Train";

		private void Awake()
		{
			btnProfile.onClick.AddListener(() => UniTask.Void(Profile));

			btnModel.onClick.AddListener(() => UniTask.Void(Model));

			btnExamine.onClick.AddListener(() => UniTask.Void(Examine));

			btnTrain.onClick.AddListener(() => UniTask.Void(Train));

			btnReport.onClick.AddListener(() => UniTask.Void(Report));
		}

		async UniTaskVoid Profile()
		{
			await UIKit.CloseAllAwait();
			await UIKit.OpenAwait<ProfilePanel>();
		}

		async UniTaskVoid Model()
		{
			await UIKit.CloseAllAwait();
			await UIKit.OpenAwait<ModelPanel>();
		}

		async UniTaskVoid Examine()
		{
			await UIKit.CloseAllAwait();
			await UIKit.OpenAwait<ExaminePanel>();
		}

		async UniTaskVoid Train()
		{
			await UIKit.CloseAllAwait();
			await UIKit.OpenAwait<GamePanel>();
		}

		async UniTaskVoid Report()
		{
			await UIKit.CloseAllAwait();
			await UIKit.OpenAwait<ReportPanel>();
		}
	}
}
