using Microsoft.AspNetCore.Mvc;
using PhonePlanAPI.Data;
using PhonePlanAPI.Models;

namespace PhonePlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanTypeController : ControllerBase
    {
        private readonly PlanTypeRepository _planTypeRepository;
        public PlanTypeController(PlanTypeRepository planTypeRepository)
        {
            _planTypeRepository = planTypeRepository;
        }

        [HttpGet]
        public ActionResult<List<PlanType>> Get()
        {
            var result = _planTypeRepository.GetAll();
            return Ok(result);
        }
    }
}