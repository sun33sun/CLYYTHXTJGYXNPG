namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class ReportPanel
	{
		[HideInInspector, SerializeField] public UnityEngine.RectTransform ReportParent = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnSubmit = null;
	
		public ReportPanelData mData => UIDataMgr.Get<ReportPanelData>();
	}
}
