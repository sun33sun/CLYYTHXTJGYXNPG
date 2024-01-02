using ProjectBase.Extension.AnimExtension;

namespace ProjectBase.UI
{
	public partial class ObjHelp : BaseController
	{
		private void Awake()
		{
			btnClose.onClick.AddListener(()=>this.HideAsync());
		}
	}
}
