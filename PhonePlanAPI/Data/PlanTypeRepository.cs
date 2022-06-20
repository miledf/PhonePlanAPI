using PhonePlanAPI.Models;

namespace PhonePlanAPI.Data
{
    public class PlanTypeRepository
    {
        private readonly DataContext _dataContext;

        public PlanTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<PlanType> GetAll()
        {
            return _dataContext.PlanTypes.AsEnumerable();
        }
    }
}
