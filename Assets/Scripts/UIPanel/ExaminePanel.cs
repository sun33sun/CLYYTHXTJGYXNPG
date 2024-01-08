using Cysharp.Threading.Tasks;
using System.Threading;

namespace ProjectBase.UI
{
	public class ExaminePanelData : IData
	{

	}
	public partial class ExaminePanel : UIController
	{
		const string QuestionPrefab = "QuestionPrefab";
		const string OptionPrefab = "OptionPrefab";
		const string ExamineJson = "ExamineJson";

		const string DoubleConfirm = "\t您正在提交答案，该过程无法撤销。您确定要这么做吗？";

		private void Awake()
		{
			svQuestion.LoadQuestion(ExamineJson, QuestionPrefab, OptionPrefab);

			btnSubmit.OnClickAwait(Submit);
		}

		async UniTask Submit(CancellationToken btnToken)
		{
			bool isConfirm = await UIKit.Get<TopPanel>().AwaitDoubleConfirm(DoubleConfirm, btnToken);
			if (isConfirm)
			{
				await UIKit.Get<BottomPanel>().BackMainPanel(btnToken);
			}
		}
	}
}
