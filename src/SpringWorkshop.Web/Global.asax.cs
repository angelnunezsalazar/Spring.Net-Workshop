using System.Collections.Specialized;
using System.Web;
using SpringWorkshop.CrossCutting.Bootstrapping;

namespace SpringWorkshop.Web
{
    public class MvcApplication : HttpApplication
    {
        public override void Init()
        {
            base.Init();
            StartUp.Init();
        }
    }
}