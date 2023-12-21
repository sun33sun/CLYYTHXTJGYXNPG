using Cysharp.Threading.Tasks;

namespace ProjectBase.UI
{
	public static class UIKit
	{
		public static void Init()
		{
			UIMgr instance = UIMgr.Instance;
		}

		#region 创建
		public static T Open<T>() where T : UIController
		{
			return UIMgr.Instance.Open<T>();
		}

		public static async UniTask<T> OpenAsync<T>() where T : UIController
		{
			T t = await UIMgr.Instance.OpenAsync<T>();
			return t;
		}
		#endregion

		#region 关闭
		public static void Close()
		{
			UIMgr.Instance.Close();
		}

		public static async UniTask CloseAsync()
		{
			await UIMgr.Instance.CloseAsync();	
		}

		public static void CloseAll()
		{
			UIMgr.Instance.CloseAll();
		}
		#endregion

		/// <summary>
		/// 获取
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Get<T>() where T : UIController
		{
			return UIMgr.Instance.Get<T>();
		}

		#region 显示
		public static void Show<T>() where T : UIController
		{
			UIMgr.Instance.Show<T>();
		}

		public static void ShowFade<T>() where T : UIController
		{
			UIMgr.Instance.ShowFade<T>();
		}

		#endregion

		#region 隐藏
		public static void Hide<T>() where T : UIController
		{
			UIMgr.Instance.Hide<T>();
		}

		public static void HideFade<T>() where T : UIController
		{
			UIMgr.Instance.HideFade<T>();
		}
		#endregion
	}
}

