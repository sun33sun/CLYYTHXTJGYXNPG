namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class MainPanel
	{
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnProfile = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnModel = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnExamine = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnTrain = null;
		[HideInInspector, SerializeField] public UnityEngine.UI.Button btnReport = null;
	
		public MainPanelData mData => UIDataMgr.Get<MainPanelData>();
	}
}
