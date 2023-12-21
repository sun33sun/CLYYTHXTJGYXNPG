using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks.Triggers;
using Cysharp.Threading.Tasks.Linq;
using ProjectBase.UI;

namespace ProjectBase
{
	public static class UIHelper
	{
		public static float HideTime = 0.5f;
		public static float ShowTime = 0.5f;

		/// <summary>
		/// 执行异步函数过程中会屏蔽所有UI交互
		/// </summary>
		/// <param name="btn"></param>
		/// <param name="invoke"></param>
		public static void AddAwaitAction(this Button btn, Func<UniTask> invoke)
		{
			CancellationToken token = btn.GetCancellationTokenOnDestroy();
			UnityAction asyncAction = async () =>
			{
				if (token.IsCancellationRequested) return;
				UIRoot.Interactable = true;
				await invoke();
				UIRoot.Interactable = false;
			};
			btn.onClick.AddListener(asyncAction);
		}

		/// <summary>
		/// 执行异步函数过程中会屏蔽所有UI交互
		/// </summary>
		/// <param name="tog"></param>
		/// <param name="invoke"></param>
		public static void AddAwaitAction(this Toggle tog, Func<bool, UniTask> invoke)
		{
			CancellationToken token = tog.GetCancellationTokenOnDestroy();
			UnityAction<bool> asyncAction = null;
			//有group的情况下，会同时触发两个toggle，因此屏蔽由isOn的Toggle管理。
			asyncAction = async isOn =>
			{
				if (token.IsCancellationRequested) return;
				if (isOn)
				{
					UIRoot.Interactable = true;
					await invoke(isOn);
					UIRoot.Interactable = false;
				}
				else
				{
					await invoke(isOn);
				}
			};

			tog.onValueChanged.AddListener(asyncAction);
		}
	}
}