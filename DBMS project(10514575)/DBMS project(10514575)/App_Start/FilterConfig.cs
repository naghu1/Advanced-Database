using System.Web;
using System.Web.Mvc;

namespace DBMS_project_10514575_
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
