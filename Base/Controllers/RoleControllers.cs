

using Microsoft.AspNetCore.Mvc;
using Base.Models;
using Base.Services;
using Microsoft.AspNetCore.Authorization;

namespace Base.Controllers
{
    [Route("api/roles")]
    [Authorize]
    public class RoleController : GenericController<Role>
    {
        public RoleController(IGenericService<Role> service) : base(service)
        {
        }
    }
}
