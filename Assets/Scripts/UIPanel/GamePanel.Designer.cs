namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class GamePanel
	{
		[HideInInspector, SerializeField] public ProjectBase.UI.ObjTip ObjTip = null;
		[HideInInspector, SerializeField] public ProjectBase.UI.ObjExamine ObjExamine = null;
	
		public GamePanelData mData => UIDataMgr.Get<GamePanelData>();
	}
}
