namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class ExaminePanel
	{
		[HideInInspector, SerializeField] public ProjectBase.Exam.QuestionParent svQuestion = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnSubmit = null;
	
		public ExaminePanelData mData => UIDataMgr.Get<ExaminePanelData>();
	}
}
