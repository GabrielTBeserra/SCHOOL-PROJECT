using SCHOOL_PROJECT_COMMON.Helpers.HttpContext;

namespace SCHOOL_PROJECT_COMMON.Configurations.Service
{
    public abstract class BaseService
    {
        protected string LoggedUser
        {
            get { return HttpHelper.LoggedUser; }
        }
    }
}
