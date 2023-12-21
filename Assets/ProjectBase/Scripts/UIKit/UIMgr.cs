using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;
using ProjectBase.CodeGenKit;
using System.Linq;
using DG.Tweening;
using ProjectBase.Res;

namespace ProjectBase.UI
{
	public class UIMgr : Singleton<UIMgr>
	{
		public const float ShowTime = 0.5f;
		public const float HideTime = 0.5f;

		Dictionary<Type, UIController> instanceDic = new Dictionary<Type, UIController>();

		public ManagerState loadState { get; private set; }

		#region ����
		/// <summary>
		/// ����Ԥ����
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T Load<T>() where T : UIController
		{
			Type type = typeof(T);
			//����������
			if (instanceDic.ContainsKey(type))
				GameObject.Destroy(instanceDic[type]);
			//����һ�����Ľ����ر�
			if (instanceDic.Count > 0)
				instanceDic.Last().Value.group.interactable = false;
			//�����¼��ص����
			T t = GameObject.Instantiate(ResMgr.Instance[type], UIRoot.Instance.CommomLayer) as T;
			t.canvas.overrideSorting = true;
			t.canvas.sortingOrder = instanceDic.Count;
			t.name = ResMgr.Instance[type].name;
			instanceDic[type] = t;
			return t;
		}

		public T Open<T>() where T : UIController
		{
			T t = Load<T>();
			t.group.alpha = 1;
			t.group.interactable = true;

			return t;
		}

		public async UniTask<T> OpenAsync<T>() where T : UIController
		{
			T t = Load<T>();
			await t.group.DOFade(1, ShowTime).AsyncWaitForCompletion();
			t.group.interactable = true;
			return t;
		}
		#endregion

		#region �ر�
		KeyValuePair<Type, UIController> Pop()
		{
			KeyValuePair<Type, UIController> pair = instanceDic.Last();
			instanceDic.Remove(pair.Key);
			return pair;
		}

		public void Close()
		{
			if (instanceDic.Count < 1)
				return;
			GameObject.Destroy(Pop().Value);
		}

		public async UniTask CloseAsync()
		{
			if (instanceDic.Count < 1)
				return;

			UIController controller = Pop().Value;
			controller.group.interactable = false;
			//����
			await controller.group.DOFade(0, ShowTime).AsyncWaitForCompletion();
			//����
			GameObject.Destroy(controller);
		}

		public void CloseAll()
		{
			for (int i = 0; i < instanceDic.Count; i++)
			{
				GameObject go = Pop().Value.gameObject;
				GameObject.Destroy(go);
			}
			instanceDic.Clear();
		}
		#endregion

		public T Get<T>() where T : UIController
		{
			Type type = typeof(T);
			if (instanceDic.ContainsKey(type))
			{
				return instanceDic[type] as T;
			}
			else
			{
				return null;
			}
		}

		#region ��ʾ
		public void Show<T>() where T : UIController
		{
			T t = Get<T>();
			if (t != null)
			{
				t.gameObject.SetActive(true);
				t.group.interactable = true;
				t.group.alpha = 1;
			}
		}

		public async void ShowFade<T>() where T : UIController
		{
			T t = Get<T>();
			if (t != null)
			{
				t.gameObject.SetActive(true);
				await t.group.DOFade(1, ShowTime).AsyncWaitForCompletion();
				t.group.interactable = true;
			}
		}

		#endregion

		#region ����
		public void Hide<T>() where T : UIController
		{
			T t = Get<T>();
			if (t != null)
			{
				t.gameObject.SetActive(false);
				t.group.interactable = false;
				t.group.alpha = 0;
			}
		}

		public async void HideFade<T>() where T : UIController
		{
			T t = Get<T>();
			if (t != null)
			{
				t.group.interactable = false;
				await t.group.DOFade(0, HideTime).AsyncWaitForCompletion();
				t.gameObject.SetActive(false);
			}
		}
		#endregion
	}
}

