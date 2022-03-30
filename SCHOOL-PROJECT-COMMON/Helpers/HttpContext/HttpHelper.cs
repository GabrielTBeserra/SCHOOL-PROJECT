using SCHOOL_PROJECT_COMMON.Configurations.Http;

namespace SCHOOL_PROJECT_COMMON.Helpers.HttpContext
{
    public static class HttpHelper
    {
        public static string LoggedUser
        {
            get { return HttpContextGetter.ContextAcessor.HttpContext?.User.Identity.Name; }
        }
    }
}
