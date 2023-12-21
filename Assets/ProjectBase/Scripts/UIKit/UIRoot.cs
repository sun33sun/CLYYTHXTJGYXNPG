using ProjectBase.Res;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectBase.UI
{
	public class UIRoot : PersistentSingletonMono<UIRoot>
	{
		public EventSystem eventSystem;
		public Camera uiCamera;
		public Canvas canvas;
		public CanvasScaler canvasScaler;
		
		/// <summary>
		/// ��嶼�ŵ�����
		/// </summary>
		public RectTransform CommomLayer;
		/// <summary>
		/// �ò��ṩ��ܵ�ͨ�ù���
		/// </summary>
		public RectTransform FrameworkLayer;
		/// <summary>
		/// �ڱ����н���
		/// </summary>
		public GameObject imgMask;
		public static bool Interactable
		{
			get => Instance.imgMask.activeInHierarchy;
			set => Instance.imgMask.SetActive(value);
		}

		protected override void Awake()
		{
			ResMgr resMgr = ResMgr.Instance;
			UIMgr uiMgr = UIMgr.Instance;
			DataMgr dataMgr = DataMgr.Instance;

			base.Awake();
		}
	}
}

