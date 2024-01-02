
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using ProjectBase.Extension.AnimExtension;
using System.Threading;

namespace ProjectBase.UI
{
	public class TopPanelData : UIData
	{

	}
	public partial class TopPanel : UIController
	{
		public async UniTask<bool> AwaitDoubleConfirm(string newContent, CancellationToken token)
		{
			CancellationTokenSource link = CancellationTokenSource.CreateLinkedTokenSource(token,this.GetCancellationTokenOnDestroy());
			bool isConfirm = await ObjDoubleConfirm.AwaitDoubleConfirm(newContent, link.Token);
			return isConfirm;
		}

		public void ShowHelpAsync()
		{
			if(!ObjHelp.gameObject.activeInHierarchy)
				ObjHelp.ShowAsync();
		}

		public async UniTask AwaitPop(string newContent,CancellationToken token)
		{
			CancellationTokenSource link = CancellationTokenSource.CreateLinkedTokenSource(token, this.GetCancellationTokenOnDestroy());
			await ObjPop.AwaitPop(newContent, link.Token);
		}
	}
}
