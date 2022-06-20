using PhonePlanAPI.Data;
using PhonePlanAPI.Models;

namespace PhonePlanAPI.Services
{
    public class PhonePlanService
    {
        private readonly PhonePlanRepository _phonePlanRepository;

        public PhonePlanService(PhonePlanRepository phonePlanRepository)
        {
            _phonePlanRepository = phonePlanRepository;
        }

        public IEnumerable<PhonePlanDTO> GetAllPhonePlans()
        {
            return _phonePlanRepository.GetAll().Select(x => x.MapToPhonePlanDTO());
        }

        public IEnumerable<PhonePlanDTO> GetAllPhonePlansByDDD(int ddd)
        {
            return _phonePlanRepository.GetAllByDDD(ddd).Select(x => x.MapToPhonePlanDTO());
        }

        public async Task<PhonePlanDTO> GetById(int id)
        {
            return (await _phonePlanRepository.GetById(id)).MapToPhonePlanDTO();
        }

        public async Task PostAsync(PhonePlanDTO phonePlanDTO)
        {
            var phonePlan = phonePlanDTO.MapToPhonePlan();

            await _phonePlanRepository.Post(phonePlan);
        }

        public async Task UpdateAsync(int id, PhonePlanDTO phonePlanDTO)
        {
            var phonePlan = await _phonePlanRepository.GetById(id);

            if (phonePlan == null)
                throw new Exception("phone plan not founded.");

            phonePlan.Value = phonePlanDTO.Value;
            phonePlan.Minutes = phonePlanDTO.Minutes;
            phonePlan.Internet = phonePlanDTO.Internet;
            phonePlan.IdOperator = phonePlanDTO.IdOperator;
            phonePlan.IdPlanType = phonePlanDTO.IdPlanType;
            phonePlan.DDDs = phonePlanDTO.DDDs?.Select(x => new PlanDDD { IdDDD = x, IdPhonePlan = phonePlanDTO.Id }).ToList();

            _phonePlanRepository.Update(phonePlan);
        }

        public async Task RemoveAsync(int id)
        {
            var phonePlan = await _phonePlanRepository.GetById(id);

            if (phonePlan == null)
                throw new Exception("phone plan not founded.");

            await _phonePlanRepository.RemoveAsync(phonePlan);
        }
    }
}
