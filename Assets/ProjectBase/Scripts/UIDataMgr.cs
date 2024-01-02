using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

namespace ProjectBase
{
	public interface UIData
	{
	}
	public partial class UIDataMgr : Singleton<UIDataMgr>
	{
		Dictionary<Type, UIData> dataDic = new Dictionary<Type, UIData>();

		private UIDataMgr() { }
		public override void OnSingletonInit()
		{
			Init();
		}

		public static T Get<T>() where T : UIData
		{
			Type type = typeof(T);
			return (T)Instance.dataDic[type];
		}
	}
}

