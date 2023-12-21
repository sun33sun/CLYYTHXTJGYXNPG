using UnityEngine;

namespace ProjectBase.UI
{
	public partial class MainPanel
	{
		[HideInInspector] public UnityEngine.GameObject btnProfile = null;
		[HideInInspector] public UnityEngine.GameObject btnTrain = null;
		[HideInInspector] public UnityEngine.GameObject btnExamine = null;
		[HideInInspector] public UnityEngine.GameObject btnReport = null;
	
		public new MainPanelData mData => DataMgr.Get<MainPanelData>();
	}
}
