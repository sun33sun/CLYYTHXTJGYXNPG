using Cysharp.Threading.Tasks;
using ProjectBase.Extension.AnimExtension;
using System.Threading;

namespace ProjectBase.Game
{
	public partial class ObjDoubleConfirm : BaseController
	{
		private void Awake()
		{

		}

		public async UniTask<bool> AwaitDoubleConfirm(string newContent,CancellationToken otherToken)
		{
			CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(this.GetCancellationTokenOnDestroy(), otherToken);

			tmpContent.text = newContent;
			await this.ShowAwait();
			int index = await UniTask.WhenAny(btnConfirm.OnClickAsync(cts.Token), btnCancel.OnClickAsync(cts.Token));
			await this.HideAwait();

			return index == 0;
		}
	}
}
