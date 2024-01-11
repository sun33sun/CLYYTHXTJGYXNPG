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
	public static class ButtonHelper
	{
		public static float HideTime = 0.5f;
		public static float ShowTime = 0.5f;

		/// <summary>
		/// ִ���첽���������л���������UI����
		/// </summary>
		/// <param name="btn"></param>
		/// <param name="invoke"></param>
		public static void OnClickAwait(this Button btn, Func<CancellationToken, UniTask> invoke)
		{
			var awaitEnumerable = btn.OnClickAsAsyncEnumerable();
			CancellationToken btnToken = btn.GetCancellationTokenOnDestroy();
			UniTask.Void(async () =>
			{
				await awaitEnumerable.ForEachAwaitAsync(async _ =>
				{
					await invoke(btnToken);
				}, btnToken);
			});
		}
	}
}