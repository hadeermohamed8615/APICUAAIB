using APICUAAIB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICUAAIB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BindingController : ControllerBase
    {
        //Bind Primitive DT => Route Data (Segment)
        //Bind Complex DT => Request Body
        [HttpGet("{id:int}")] //api/binding/1?name = ali
        public IActionResult Get1([FromRoute]int id,string name) //1)Segment 2)Query String 3)Request Body 4)set Default
        {
            return Ok();
        }

        [HttpGet("complix/{id}")] //api/binding?id=1&name=sd&location=cairo //xxxxx  api/binding/1/sd/cairo 
                    //Request Body
        public IActionResult Get2(Department d) //1)Segment 2)Query String 3)Request Body 4)set Default
        {
            return Ok();
        }
    }
}
