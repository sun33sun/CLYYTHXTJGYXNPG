
using UnityEngine;
using System;
using ProjectBase.UI;

namespace ProjectBase.Game
{
	public class ReportData
	{
		public string reportName;
		public DateTime startTime;
		public DateTime endTime;
		public float getedScore;
		public bool initialized;

		public ReportData(string reportName)
		{
			this.reportName = reportName;
		}
	}
	public partial class ReportItem : ViewController
	{
	}
}
