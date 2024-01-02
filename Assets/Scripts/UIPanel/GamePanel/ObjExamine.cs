using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using System.Threading;
using ProjectBase.Extension.AnimExtension;

namespace ProjectBase.UI
{
	public partial class ObjExamine : BaseController
	{
		const string QuestionPrefab = "QuestionPrefab";
		const string OptionPrefab = "OptionPrefab";
		const string DoubleConfirmTip = "您确定要提交答案吗？该操作无法撤销！";

		private void Awake()
		{

		}

		public async UniTask WaitExamine(string jsonName, CancellationToken token)
		{
			CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(token, this.GetCancellationTokenOnDestroy());

			svQuestion.LoadQuestion(jsonName, QuestionPrefab, OptionPrefab);
			LayoutRebuilder.ForceRebuildLayoutImmediate(svQuestion.transform as RectTransform);
			await this.ShowAwait();

			bool submited = false;
			while (!submited)
			{
				await btnSubmit.OnClickAsync(cts.Token);
				submited = await UIKit.Get<TopPanel>().AwaitDoubleConfirm(DoubleConfirmTip, cts.Token);
				if(submited)
				{
					svQuestion.Submit();
					break;
				}
			}

			await btnSubmit.OnClickAsync(cts.Token);
			this.HideAsync();
		}
	}
}
