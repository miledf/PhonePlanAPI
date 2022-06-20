using Microsoft.AspNetCore.Mvc;
using PhonePlanAPI.Data;
using PhonePlanAPI.Models;

namespace PhonePlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatorController : ControllerBase
    {
        private readonly OperatorRepository _operatorRepository;
        public OperatorController(OperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        [HttpGet]
        public ActionResult<List<Operator>> Get()
        {
            var result = _operatorRepository.GetAll();
            return Ok(result);
        }
    }
}