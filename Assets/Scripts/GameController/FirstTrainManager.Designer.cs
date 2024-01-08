namespace ProjectBase.Game
{
	using UnityEngine;

	public partial class FirstTrainManager
	{
		[HideInInspector, SerializeField] public UnityEngine.Playables.PlayableDirector director = null;
		[HideInInspector, SerializeField] public UnityEngine.Camera TrainCamera = null;
	
	}
}
