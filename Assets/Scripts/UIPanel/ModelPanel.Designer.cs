namespace ProjectBase.UI
{
	using UnityEngine;

	public partial class ModelPanel
	{
		[HideInInspector, SerializeField] public UnityEngine.UI.RawImage RenderCanvas = null;
		[HideInInspector, SerializeField] public UnityEngine.Camera RenderModelCamera = null;
		[HideInInspector, SerializeField] public ProjectBase.UI.ModelSelection ModelSelection = null;
	
		public ModelPanelData mData => UIDataMgr.Get<ModelPanelData>();
	}
}
