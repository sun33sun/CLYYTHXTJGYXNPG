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
			EnumEventSystem.Instance.Register(TrainState.EndTrain, OnEndTrain);
		}

		void OnEndTrain()
		{
			director.Stop();
		}
	}
}
