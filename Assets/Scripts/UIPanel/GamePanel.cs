using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using ProjectBase.Game;
using System.Threading;

namespace ProjectBase.UI
{
	public class GamePanelData : IData
	{

	}

	public partial class GamePanel : UIController
	{
		private void Awake()
		{
			
		}

		public async UniTask WaitExamine(string jsonName, CancellationToken token)
		{
			CancellationTokenSource link = CancellationTokenSource.CreateLinkedTokenSource(token, this.GetCancellationTokenOnDestroy());
			await ObjExamine.WaitExamine(jsonName, link.Token);
		}

		public void ChangeTip(string newContent)
		{
			ObjTip.ChangeTip(newContent);
		}
	}
}
