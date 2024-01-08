using Cysharp.Threading.Tasks;
using ProjectBase.EnumExtension;
using ProjectBase.Game;
using ProjectBase.Res;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProjectBase.UI
{
	public enum ReportName
	{
		实验概述, 知识考核
	}

	public class ReportPanelData : IData
	{
		public Dictionary<ReportName, ReportData> enumDic = new Dictionary<ReportName, ReportData>();

		public ReportPanelData()
		{
			foreach (var item in EnumHelper.All<ReportName>())
			{
				enumDic.Add(item, new ReportData(item.ToString()));
			}
		}

		public void UpdateStartTime(ReportName reportName)
		{
			ReportData reportData = enumDic[reportName];
			reportData.startTime = DateTime.Now;
			reportData.initialized = false;
			reportData.getedScore = 0;
		}

		public void AddScore(ReportName reportName, float addend)
		{
			ReportData reportData = enumDic[reportName];
			reportData.getedScore += addend;
		}

		public void UpdateEndTime(ReportName reportName)
		{
			ReportData reportData = enumDic[reportName];
			reportData.endTime = DateTime.Now;
			reportData.initialized = true;
		}
	}

	public partial class ReportPanel : UIController
	{
		List<ReportItem> items = new List<ReportItem>();

		const string DoubleConfirm = "\t您正在提交实验报告，该过程无法撤销。您确定要这么做吗？";

		private void Awake()
		{
			GenerateReportItem();

			btnSubmit.OnClickAwait(Submit);
		}

		/// <summary>
		/// 生成实验报告
		/// </summary>
		void GenerateReportItem()
		{
			ReportItem prefab = ResMgr.Instance.GetPrefab<ReportItem>();
			foreach (var data in mData.enumDic.Values)
			{
				ReportItem item = Instantiate(prefab, ReportParent);
				items.Add(item);

				item.tmpReportNanme.text = $"报告名称：{data.reportName}";
				item.tmpStartTime.text = "开始时间：未开始";
				item.tmpEndTime.text = "结束时间：未开始";
				item.tmpTimeSpan.text = "时间间隔：未开始";
				item.tmpGetedScore.text = "得分：0";
			}
		}

		async UniTask Submit(CancellationToken btnToken)
		{
			bool isConfirm = await UIKit.Get<TopPanel>().AwaitDoubleConfirm(DoubleConfirm, this.GetCancellationTokenOnDestroy());

			if(isConfirm)
			{
				await UIKit.Get<BottomPanel>().BackMainPanel(btnToken);
			}
		}
	}
}
