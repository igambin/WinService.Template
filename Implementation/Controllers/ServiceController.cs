using System;
using System.Web.Http;
using Microsoft.Practices.Unity;
using WinService.Logging;
using WinService.UnitySetup;

namespace WinService.Implementation.Controllers
{
    [RoutePrefix("Service")]
    public class ServiceController : ApiController
    {
        IUnityContainer _container;
        public ServiceController()
        {
            _container = UnityConfig.Container;
        }

        [Route("Status")]
        [HttpGet]
        public IHttpActionResult GetTrayportClientStatus()
        {
            try
            {
                var status = "OK (implement logic to retrieve ServiceStatus here)";
                return Ok(status);
            }
            catch (Exception ex)
            {
                this.FileLogger().Error("Getting Status caused an exception.", ex);
                return InternalServerError(ex);
            }
        }
        
    }

}
