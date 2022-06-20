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

        public async Task PostAsync(PhonePlanDTO phonePlanDTO)
        {
            var phonePlan = GetPhonePlan(phonePlanDTO);

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

        public IEnumerable<PhonePlanDTO> GetAllPhonePlans()
        {
            return _phonePlanRepository.GetAll().Select(x => GetPhonePlan(x));
        }

        public IEnumerable<PhonePlanDTO> GetAllPhonePlansByDDD(int ddd)
        {
            return _phonePlanRepository.GetAllByDDD(ddd).Select(x => GetPhonePlan(x));
        }

        private PhonePlanDTO GetPhonePlan(PhonePlan phonePlan)
        {
            return new PhonePlanDTO
            {
                Id = phonePlan.Id,
                IdPlanType = phonePlan.IdPlanType,
                IdOperator = phonePlan.IdOperator,
                Value = phonePlan.Value,
                Internet = phonePlan.Internet,
                Minutes = phonePlan.Minutes,
                DDDs = phonePlan.DDDs?.Select(x => x.IdDDD).ToList()
            };
        }

        public async Task<PhonePlanDTO> GetById(int id)
        {
            return GetPhonePlan(await _phonePlanRepository.GetById(id));
        }

        private PhonePlan GetPhonePlan(PhonePlanDTO phonePlanDTO)
        {
            return new PhonePlan
            {
                Id = phonePlanDTO.Id,
                Internet = phonePlanDTO.Internet,
                Minutes = phonePlanDTO.Minutes,
                Value = phonePlanDTO.Value,
                IdOperator = phonePlanDTO.IdOperator,
                IdPlanType = phonePlanDTO.IdPlanType,
                DDDs = phonePlanDTO.DDDs?.Select(x => new PlanDDD { IdDDD = x, IdPhonePlan = phonePlanDTO.Id }).ToList()
            };
        }
    }
}
