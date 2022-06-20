using Microsoft.AspNetCore.Mvc;
using PhonePlanAPI.Data;
using PhonePlanAPI.Models;

namespace PhonePlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DDDController : ControllerBase
    {
        private readonly DDDRepository _dDDRepository;
        public DDDController(DDDRepository dDDRepository)
        {
            _dDDRepository = dDDRepository;
        }

        [HttpGet]
        public ActionResult<List<DDD>> Get()
        {
            var result = _dDDRepository.GetAll();
            return Ok(result);
        }
    }
}