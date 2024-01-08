using UnityEngine;
using System;
using ProjectBase.UI;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;

namespace ProjectBase.Game
{
	public enum TrainState
	{
		EndTrain
	}
	public partial class FirstTrainManager : ViewController
	{
		BottomPanel bottomPanel = null;
		private void Awake()
		{
			bottomPanel = UIKit.Get<BottomPanel>();
			bottomPanel.ShowBackground = false;
			EnumEventSystem.Instance.Register(TrainState.EndTrain, OnEndTrain);

			AddToMainCamera(TrainCamera);
		}

		void AddToMainCamera(Camera camera)
		{
			camera.gameObject.SetActive(true);
			Camera.main.GetUniversalAdditionalCameraData().cameraStack.Insert(0, camera);
		}

		void RemoveCamera(Camera camera)
		{
			camera.gameObject.SetActive(false);
			List<Camera> stack = Camera.main.GetUniversalAdditionalCameraData().cameraStack;
			if (stack.Contains(camera))
			{
				stack.Remove(camera);
			}
		}

		void OnEndTrain()
		{
			bottomPanel.ShowBackground = true;
			director.Stop();

			RemoveCamera(TrainCamera);
		}
	}
}
