namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class BottomPanel
	{
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnHelp = null;
		[HideInInspector, SerializeField] public ProjectBase.PointerEventTrigger btnScreen = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnMain = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Image imgBk = null;
	
		public BottomPanelData mData => UIDataMgr.Get<BottomPanelData>();
	}
}
