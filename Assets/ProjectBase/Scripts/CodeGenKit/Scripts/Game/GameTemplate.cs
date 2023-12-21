namespace ProjectBase.CodeGenKit
{
	public class GameTemplate : Template
	{
		public string ClassTemplate =>
@"
using UnityEngine;
using System;
namespace #NAMESPACE#
{
	public partial class #CLASSNAME# : GameController
	{
		
	}
}
";

		public string DesignerTemplate =>
@"namespace #NAMESPACE#
{
	using UnityEngine;

	public partial class #CLASSNAME#
	{
	#MEMBER#
		public new #CLASSNAME#Data mData => DataMgr.Get<#CLASSNAME#Data>();
	}
}
";

		public string NameSpace => "ProjectBase.Game";

		public string PrefabPath => "GameController";

		public string CodePath => "Scripts/GameController";
	}
}