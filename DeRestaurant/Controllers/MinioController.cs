using System;
using Microsoft.AspNetCore.Mvc;
using Minio;
using DeRestaurant.Minio;
using System.Net;
using DeRestaurant.Repository.IRepository;

namespace DeRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinioController : ControllerBase
	{
        private readonly ILogger<MinioController> _logger;
        private readonly MinioObject _minio;
        public MinioController(ILogger<MinioController> logger, MinioObject minio)
        {
            _logger = logger;
            _minio = minio;
        }

        [HttpGet]
        public async Task<ActionResult> Get(string objectname)
        {
            var result = await _minio.GetObject("my-bucket", objectname);
            return File(result.data, result.objectstat.ContentType);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] IFormFile request)
        {
            if (request.Length < 2097152)
            {
                using (var ms = new MemoryStream())
                {
                    request.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var result = await _minio.PutObj(new PutObjectRequest()
                    {
                        bucket = "my-bucket",
                        data = fileBytes,
                    }) ;
                    return Ok(new { filename = result });
                }
            }
            return BadRequest("File larger than 2MB!");
        }

    }
}

