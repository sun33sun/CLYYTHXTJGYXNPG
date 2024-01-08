using UnityEngine;
using System;
using ProjectBase.Game;
using Cysharp.Threading.Tasks.Linq;
using Cysharp.Threading.Tasks;

namespace ProjectBase.UI
{
	public class ModelPanelData : IData
	{

	}

	public partial class ModelPanel : UIController
	{
		[SerializeField] private GameObject[] models;
		int nowId = 0;
		//[SerializeField] RenderTexture renderTexture = null;

		private void Awake()
		{
			models[nowId].SetActive(true);
			ModelSelection.modelId.ForEachAsync(modelId =>
			{
				//RenderModelCamera.activeTexture.Release();
				models[nowId].SetActive(false);
				nowId = modelId;
				models[nowId].SetActive(true);
			}).Forget();
		}


		private void Start()
		{

		}

		private void OnDestroy()
		{
		}
	}
}
