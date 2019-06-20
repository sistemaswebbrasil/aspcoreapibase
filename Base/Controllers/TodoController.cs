

using Microsoft.AspNetCore.Mvc;
using Base.Models;
using Base.Services;

namespace Base.Controllers
{
    [Route("api/todos")]
    public class TodoController : GenericController<Todo>
    {
        public TodoController(IGenericService<Todo> service) : base(service)
        {
        }
    }
}
