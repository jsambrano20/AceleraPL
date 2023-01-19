using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_MYSQL.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(IFormFile image)
        {
            if (image == null) return null;

            using (var stream = new FileStream(Path.Combine("imagens", image.FileName), FileMode.Create))
            {
                image.CopyTo(stream);
            }
            return Ok();
        }
    }
}