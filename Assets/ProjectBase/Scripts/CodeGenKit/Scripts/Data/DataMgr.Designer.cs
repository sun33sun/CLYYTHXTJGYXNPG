using ProjectBase.UI;
using ProjectBase.Game;

namespace ProjectBase
{
	public partial class DataMgr
	{
		void Init()
		{
			dataDic.Add(typeof(MainPanelData), new MainPanelData());
		dataDic.Add(typeof(BottomPanelData), new BottomPanelData());
	
		}
	}
}
