using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

namespace ProjectBase
{
	public interface IData
	{
	}
	public partial class UIDataMgr : Singleton<UIDataMgr>
	{
		Dictionary<Type, IData> dataDic = new Dictionary<Type, IData>();

		private UIDataMgr() { }
		public override void OnSingletonInit()
		{
			Init();
		}

		public static T Get<T>() where T : IData
		{
			Type type = typeof(T);
			return (T)Instance.dataDic[type];
		}
	}
}

