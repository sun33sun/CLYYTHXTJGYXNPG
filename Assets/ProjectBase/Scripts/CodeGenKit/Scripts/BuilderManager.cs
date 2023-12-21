using Newtonsoft.Json;
using Sirenix.Utilities.Editor;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectBase.CodeGenKit
{
	public class BuilderManager
	{
		BaseBuilder builder = null;

		//单例
		static BuilderManager instance = null;
		public static BuilderManager Instance
		{
			get
			{
				if (instance == null)
					instance = new BuilderManager();
				return instance;
			}
		}
		private BuilderManager()
		{

		}

		void PatternMatch(BaseBind baseBind)
		{
			if (baseBind is UIBind uiBind)
				builder = new UIBuilder(new UITemplate());
			else if (baseBind is GameBind gameBind)
				builder = new GameBuilder(new GameTemplate());
		}


		#region 第一阶段，生成代码
		/// <summary>
		/// 生成代码的帮助方法
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="content"></param>
		public void Write(string filePath, string content)
		{
			if (File.Exists(filePath))
				File.Delete(filePath);

			FileStream file = new FileStream(filePath, FileMode.CreateNew);
			StreamWriter fileW = new StreamWriter(file, System.Text.Encoding.UTF8);
			fileW.Write(content);
			fileW.Flush();
			fileW.Close();
			file.Close();
		}

		/// <summary>
		/// 生成代码的帮助方法，
		/// </summary>
		/// <param name="nameList"></param>
		public void WriteDataMgrDesigner(List<string> nameList)
		{
			StringBuilder sb = new StringBuilder();

			foreach (var name in nameList)
			{
				sb.Append($"\tdataDic.Add(typeof({name}Data), new {name}Data());\r\n\t");
			}
			string json = CodeGenGlobalSetting.DataMgrTemplate;
			json = json.Replace(CodeTemplateMarker.DATA, sb.ToString());
			Write(CodeGenGlobalSetting.DataMgrPath, json);
		}

		/// <summary>
		/// 阶段一：生成代码
		/// </summary>
		/// <param name="baseBind"></param>
		public void GenerateCode(BaseBind baseBind)
		{
			PatternMatch(baseBind);

			builder.GenerateCode(baseBind);
		}
		#endregion

		/// <summary>
		/// 阶段二：查找引用
		/// </summary>
		/// <param name="baseBind"></param>
		public void FindReference(BaseBind baseBind)
		{
			PatternMatch(baseBind);

			builder.FindReference(baseBind);
		}

		/// <summary>
		/// 阶段三：生成预制体
		/// </summary>
		/// <param name="baseBind"></param>
		public void SaveAsPrefab(BaseBind baseBind)
		{
			PatternMatch(baseBind);

			builder.SaveAsPreab(baseBind);
		}

		/// <summary>
		/// TODO:阶段四，检查生成的“代码或预制体”是否被删除。
		/// 如果被删除，要修改枚举ControllerName和数据管理器DataMgr.Designer
		/// </summary>
		public void CheckError()
		{

		}
	}
}