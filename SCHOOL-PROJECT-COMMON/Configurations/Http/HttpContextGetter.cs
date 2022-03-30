using Microsoft.AspNetCore.Http;

namespace SCHOOL_PROJECT_COMMON.Configurations.Http
{
    public static class HttpContextGetter
    {
        public static IHttpContextAccessor ContextAcessor;

        public static void Configure(IHttpContextAccessor acessor)
        {
            ContextAcessor = acessor;
        }
    }
}
