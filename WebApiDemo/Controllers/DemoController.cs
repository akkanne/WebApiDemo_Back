using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public string Greetings()
        {
            return "Hello, Hello";
        }
        //CRUD
        //Create a new Record - POST
        //Read - retrieve a single / list of record(s) - GET
        //Update - modify an existing record - PUT
        //Delete - remove an existing record - DELETE

    }
}
