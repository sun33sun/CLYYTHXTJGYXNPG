using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBase.Extension.AnimExtension
{
	public static class AnimKit
	{
		public static async UniTask ShowAwait(this Component component)
		{
			component.gameObject.SetActive(true);
			await (component.transform as RectTransform).DOScale(Vector2.one, MainHelper.AnimTime)
				.AsyncWaitForCompletion();
		}

		public static async UniTask HideAwait(this Component component)
		{
			await component.transform.DOScale(Vector2.zero, MainHelper.AnimTime).AsyncWaitForCompletion();
			component.gameObject.SetActive(false);
		}

		public static void ShowSync(this Component component)
		{
			component.gameObject.SetActive(true);
			(component.transform as RectTransform).localScale = Vector2.one;
		}

		public static void HideSync(this Component component)
		{
			(component.transform as RectTransform).localScale = Vector2.zero;
			component.gameObject.SetActive(false);
		}

		public static void ShowAsync(this Component component)
		{
			component.gameObject.SetActive(true);
			(component.transform as RectTransform).DOScale(Vector2.one, MainHelper.AnimTime);
		}

		public static void HideAsync(this Component component)
		{
			(component.transform as RectTransform).DOScale(Vector2.zero, MainHelper.AnimTime)
				.OnComplete(() => component.gameObject.SetActive(false));
		}

		public static Func<CancellationToken, Action<float>, UniTask> LerpAwaitGenerator(float start, float end, float totalDuration)
		{
			Func<CancellationToken, Action<float>, UniTask> func = async (token, action) =>
			{
				float currentDuration = 0;
				float current = start;
				while (currentDuration < totalDuration)
				{
					action(current);
					currentDuration += Time.deltaTime;
					current = Mathf.Lerp(start, end, currentDuration / totalDuration);
					await UniTask.Yield(cancellationToken: token);
				}
			};

			return func;
		}

		public static Func<CancellationToken, Action<float>, UniTaskVoid> LerpAsyncGenerator(float start, float end, float totalDuration)
		{
			Func<CancellationToken, Action<float>, UniTaskVoid> func = async (token, action) =>
			{
				float currentDuration = 0;
				float current = start;
				while (currentDuration < totalDuration)
				{
					action(current);
					currentDuration += Time.deltaTime;
					current = Mathf.Lerp(start, end, currentDuration / totalDuration);
					await UniTask.Yield(cancellationToken: token);
				}
			};
			return func;
		}

		//public static Func<CancellationToken, Action<float>, UniTask> LerpAwaitGenerator(float start, float end, float totalDuration)
		//{
		//	Func<CancellationToken, Action<float>, UniTask> func = async (token, action) =>
		//	{
		//		float currentDuration = 0;
		//		float current = start;
		//		while (currentDuration < totalDuration)
		//		{
		//			action(current);
		//			currentDuration += Time.deltaTime;
		//			Mathf.Lerp(start, end, currentDuration / totalDuration);
		//			await UniTask.Yield(cancellationToken: token);
		//		}
		//	};

		//	return func;
		//}

		public static Func<CancellationToken, Action<Vector3>, UniTaskVoid> LerpAsyncGenerator(Vector3 start, Vector3 end, float totalDuration)
		{
			Func<CancellationToken, Action<Vector3>, UniTaskVoid> func = async (token, action) =>
			{
				float currentDuration = 0;
				Vector3 current = start;
				while (currentDuration < totalDuration)
				{
					action(current);
					currentDuration += Time.deltaTime;
					Vector3.Lerp(start, end, currentDuration / totalDuration);
					await UniTask.Yield(cancellationToken: token);
				}
			};
			return func;
		}
	}
}