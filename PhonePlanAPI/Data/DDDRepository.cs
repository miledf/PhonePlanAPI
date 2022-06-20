using PhonePlanAPI.Models;

namespace PhonePlanAPI.Data
{
    public class DDDRepository
    {
        private readonly DataContext _dataContext;

        public DDDRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<DDD> GetAll()
        {
            return _dataContext.DDDs.AsEnumerable();
        }
    }
}