using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using ProjectBase.CodeGenKit;
using System.Linq;
using DG.Tweening;

namespace ProjectBase.Res
{
	public enum ManagerState
	{
		None, Loading, Loaded
	}
	public class ResMgr
	{
		#region µ¥Àý
		private static ResMgr instance;

		public static ResMgr Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ResMgr();
					instance.LoadPrefabAsync();
				}
				return instance;
			}
		}
		#endregion

		Dictionary<Type, BaseController> prefabDic = new Dictionary<Type, BaseController>();
		public BaseController this[Type key] { get { return prefabDic[key]; } }
		public ManagerState loadState { get; private set; }

		void LoadPrefabAsync()
		{
			if (loadState != ManagerState.None)
				return;

			loadState = ManagerState.Loading;

			TextAsset textAsset = Resources.Load<TextAsset>(CodeGenGlobalSetting.PrefabJsonName);
			string json = textAsset.text;
			Dictionary<string, string> dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
			if (dic == null)
				return;
			foreach (var item in dic)
			{
				UIController controller = Resources.Load<UIController>(item.Value);
				prefabDic.Add(controller.GetType(), controller);
			}

			loadState = ManagerState.Loaded;
		}
	}
}

