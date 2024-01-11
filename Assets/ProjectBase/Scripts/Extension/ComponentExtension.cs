using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBase
{
	public static class ComponentExtension
	{
		public static T GetOrAddComponent<T>(this Component self) where T : Component
		{
			var comp = self.gameObject.GetComponent<T>();
			return comp ? comp : self.gameObject.AddComponent<T>();
		}

		public static T GetOrAddComponent<T>(this GameObject self) where T : Component
		{
			var comp = self.GetComponent<T>();
			return comp ? comp : self.AddComponent<T>();
		}

		public static void ColorA<T>(this T graphic, float value) where T : Graphic
		{
			Color color = graphic.color;
			color.a = value;
			graphic.color = color;
		}
		public static float ColorA<T>(this T graphic) where T : Graphic
		{
			return graphic.color.a;
		}

		public static void PositionX(this Component component, float value)
		{
			var position = component.transform.position;
			position.x = value;
			component.transform.position = position;
		}
		public static float PositionX(this Component component) => component.transform.position.x;

		public static void PositionY(this Component component, float value)
		{
			var position = component.transform.position;
			position.y = value;
			component.transform.position = position;
		}
		public static float PositionY(this Component component) => component.transform.position.y;

		public static void PositionZ(this Component component, float value)
		{
			var position = component.transform.position;
			position.z = value;
			component.transform.position = position;
		}
		public static float PositionZ(this Component component) => component.transform.position.z;
	}
}

