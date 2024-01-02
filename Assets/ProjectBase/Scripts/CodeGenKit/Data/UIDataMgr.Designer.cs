using ProjectBase.UI;
using ProjectBase.Game;

namespace ProjectBase
{
	public partial class UIDataMgr
	{
		void Init()
		{
			dataDic.Add(typeof(MainPanelData), new MainPanelData());
			dataDic.Add(typeof(BottomPanelData), new BottomPanelData());
			dataDic.Add(typeof(ExaminePanelData), new ExaminePanelData());
			dataDic.Add(typeof(TopPanelData), new TopPanelData());
			dataDic.Add(typeof(ReportPanelData), new ReportPanelData());
			dataDic.Add(typeof(ProfilePanelData), new ProfilePanelData());
			dataDic.Add(typeof(GamePanelData), new GamePanelData());
			dataDic.Add(typeof(ModelPanelData), new ModelPanelData());
		}
	}
}
