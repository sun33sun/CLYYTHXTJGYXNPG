namespace ProjectBase.CodeGenKit
{
	public class UITemplate : Template
	{
		public string ClassTemplate =>
@"
using UnityEngine;
using System;
namespace #NAMESPACE#
{
	public class #CLASSNAME#Data : IData
	{

	}
	public partial class #CLASSNAME# : UIController
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

		public string NameSpace => "ProjectBase.UI";

		public string PrefabPath => "UIPanelPrefab";

		public string CodePath => "Scripts/UIPanel";
	}
}