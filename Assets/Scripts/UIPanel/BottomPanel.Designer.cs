namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class BottomPanel
	{
		[HideInInspector] public UnityEngine.UI.Button btnHelp = null;
		[HideInInspector] public ProjectBase.PointerEventTrigger btnScreen = null;
		[HideInInspector] public UnityEngine.UI.Button btnMain = null;
	
		public new BottomPanelData mData => DataMgr.Get<BottomPanelData>();
	}
}
