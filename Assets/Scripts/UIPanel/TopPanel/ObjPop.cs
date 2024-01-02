using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using ProjectBase.Extension.AnimExtension;
using System.Threading;

namespace ProjectBase.UI
{
	public partial class ObjPop : BaseController
	{
		public async UniTask AwaitPop(string newContent, CancellationToken token)
		{
			await this.ShowAwait();
			await btnClose.OnClickAsync(token);
			await this.HideAwait();
		}
	}
}
