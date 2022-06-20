using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PhonePlanAPI.Models;
using PhonePlanAPI.Services;

namespace PhonePlanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonePlanController : ControllerBase
    {
        private readonly PhonePlanService _phonePlanService;

        public PhonePlanController(PhonePlanService phonePlanService)
        {
            _phonePlanService = phonePlanService;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<PhonePlanDTO>> Get()
        {
            return Ok(_phonePlanService.GetAllPhonePlans());
        }

        [HttpGet("ddd/{ddd:int}")]
        [EnableQuery]
        public ActionResult<IEnumerable<PhonePlanDTO>> GetByDDD(int ddd)
        {
            return Ok(_phonePlanService.GetAllPhonePlansByDDD(ddd));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PhonePlanDTO>> Get(int id)
        {
            var result = await _phonePlanService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<PhonePlanDTO>>> Post(PhonePlanDTO phonePlanDTO)
        {
            await _phonePlanService.PostAsync(phonePlanDTO);

            return Ok(_phonePlanService.GetAllPhonePlans());
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<IEnumerable<PhonePlanDTO>>> Update(int id, PhonePlanDTO phonePlanDTO)
        {
            await _phonePlanService.UpdateAsync(id, phonePlanDTO);

            return Ok(_phonePlanService.GetAllPhonePlans());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<IEnumerable<PhonePlanDTO>>> Remove(int id)
        {
            await _phonePlanService.RemoveAsync(id);

            return Ok(_phonePlanService.GetAllPhonePlans());
        }
    }
}