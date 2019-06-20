

using Microsoft.AspNetCore.Mvc;
using Base.Models;
using Base.Services;
using Microsoft.AspNetCore.Authorization;

namespace Base.Controllers
{
    [Route("api/todos")]
    [Authorize]
    public class TodoController : GenericController<Todo>
    {
        public TodoController(IGenericService<Todo> service) : base(service)
        {
        }
    }
}
