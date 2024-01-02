using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace ProjectBase.UI
{
	public class BottomPanelData : UIData
	{

	}
	public partial class BottomPanel : UIController
	{
		const string BackMainPanelTip = "\t您确定要返回主页吗？如果返回，当前页面未提交的数据都将被撤销。";

		public bool ShowBackground
		{
			get => imgBk.enabled;
			set => imgBk.enabled = value;
		}

		private void Awake()
		{
			btnScreen.RegisterDownEvent(p => Screen.fullScreen = !Screen.fullScreen);

			btnMain.OnClickAwait(BackMainPanel);

			btnHelp.onClick.AddListener(UIKit.Get<TopPanel>().ShowHelpAsync);
		}

		public async UniTask BackMainPanel(CancellationToken btnToken)
		{
			if (UIKit.Get<MainPanel>() != null)
				return;
			CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(btnToken, this.GetCancellationTokenOnDestroy());
			bool isConfirm = await UIKit.Get<TopPanel>().AwaitDoubleConfirm(BackMainPanelTip, cts.Token);
			if (isConfirm)
			{
				await UIKit.CloseAllAwait();
				await UIKit.OpenAwait<MainPanel>();
			}
		}
	}
}
