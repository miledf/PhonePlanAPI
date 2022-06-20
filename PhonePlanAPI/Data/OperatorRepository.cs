using PhonePlanAPI.Models;

namespace PhonePlanAPI.Data
{
    public class OperatorRepository
    {
        private readonly DataContext _dataContext;

        public OperatorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Operator> GetAll()
        {
            return _dataContext.Operators.AsEnumerable();
        }
    }
}