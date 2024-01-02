using ProjectBase.Res;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectBase.UI
{
	public class UIRoot : PersistentMonoSingleton<UIRoot>
	{
		public EventSystem eventSystem;
		public Camera uiCamera;
		public Canvas canvas;
		public CanvasScaler canvasScaler;

		/// <summary>
		/// 面板都放到这里
		/// </summary>
		public RectTransform PanelRoot;

		protected override void Awake()
		{
			ResMgr resMgr = ResMgr.Instance;
			UIMgr uiMgr = UIMgr.Instance;

			base.Awake();
		}

		[Button("TODO:检查预制体是否存在一些问题")]
		public void BuildCheck()
		{
			Debug.Log("TODO:检查预制体是否存在一些问题");
		}
	}
}

