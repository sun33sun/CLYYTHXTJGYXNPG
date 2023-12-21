using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectBase
{
	public class PointerEventTrigger : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler, IPointerExitHandler
	{
		public readonly EventInfo<PointerEventData> OnPointerEnterEvent = new EventInfo<PointerEventData>();

		public readonly EventInfo<PointerEventData> OnPointerDownEvent = new EventInfo<PointerEventData>();

		public readonly EventInfo<PointerEventData> OnPointerClickEvent = new EventInfo<PointerEventData>();

		public readonly EventInfo<PointerEventData> OnPointerUpEvent = new EventInfo<PointerEventData>();

		public readonly EventInfo<PointerEventData> OnPointerExitEvent = new EventInfo<PointerEventData>();

		/// <summary>
		/// 触发鼠标进入
		/// </summary>
		/// <param name="eventData"></param>
		public void OnPointerEnter(PointerEventData eventData)
		{
			OnPointerEnterEvent.Trigger(eventData);
		}

		/// <summary>
		/// 触发鼠标按下
		/// </summary>
		/// <param name="eventData"></param>
		public void OnPointerDown(PointerEventData eventData)
		{
			OnPointerDownEvent.Trigger(eventData);
		}

		/// <summary>
		/// 触发鼠标点击
		/// </summary>
		/// <param name="eventData"></param>
		public void OnPointerClick(PointerEventData eventData)
		{
			OnPointerClickEvent.Trigger(eventData);
		}

		/// <summary>
		/// 触发鼠标抬起
		/// </summary>
		/// <param name="eventData"></param>
		public void OnPointerUp(PointerEventData eventData)
		{
			OnPointerUpEvent.Trigger(eventData);
		}

		/// <summary>
		/// 触发鼠标离开
		/// </summary>
		/// <param name="eventData"></param>
		public void OnPointerExit(PointerEventData eventData)
		{
			OnPointerExitEvent.Trigger(eventData);
		}
	}

	public static class PointerEventTriggerExtension
	{
		public static IUnRegister OnPointerEnterEvent<T>(this T self, Action<PointerEventData> onPointerClick) where T : Component
		{
			return self.GetOrAddComponent<PointerEventTrigger>().OnPointerClickEvent.Register(onPointerClick);
		}

		public static IUnRegister OnPointerDownEvent<T>(this T self, Action<PointerEventData> onPointerClick) where T : Component
		{
			return self.GetOrAddComponent<PointerEventTrigger>().OnPointerDownEvent.Register(onPointerClick);
		}

		public static IUnRegister OnPointerClickEvent<T>(this T self, Action<PointerEventData> onPointerClick) where T : Component
		{
			return self.GetOrAddComponent<PointerEventTrigger>().OnPointerClickEvent.Register(onPointerClick);
		}

		public static IUnRegister OnPointerUpEvent<T>(this T self, Action<PointerEventData> onPointerClick) where T : Component
		{
			return self.GetOrAddComponent<PointerEventTrigger>().OnPointerUpEvent.Register(onPointerClick);
		}

		public static IUnRegister OnPointerExitEvent<T>(this T self, Action<PointerEventData> onPointerClick) where T : Component
		{
			return self.GetOrAddComponent<PointerEventTrigger>().OnPointerExitEvent.Register(onPointerClick);
		}
	}
}

