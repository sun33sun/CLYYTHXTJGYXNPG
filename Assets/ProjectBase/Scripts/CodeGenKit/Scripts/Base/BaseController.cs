using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectBase
{
	public abstract class BaseController : SerializedMonoBehaviour
	{
		[HideInInspector] public IData mData;
	}
}