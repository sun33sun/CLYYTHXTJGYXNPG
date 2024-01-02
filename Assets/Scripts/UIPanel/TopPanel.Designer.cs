namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class TopPanel
	{
		[HideInInspector, SerializeField] public ProjectBase.Game.ObjDoubleConfirm ObjDoubleConfirm = null;
		[HideInInspector, SerializeField] public ProjectBase.UI.ObjPop ObjPop = null;
		[HideInInspector, SerializeField] public ProjectBase.UI.ObjHelp ObjHelp = null;
	
		public TopPanelData mData => UIDataMgr.Get<TopPanelData>();
	}
}
