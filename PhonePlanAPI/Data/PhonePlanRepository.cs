using Microsoft.EntityFrameworkCore;
using PhonePlanAPI.Models;

namespace PhonePlanAPI.Data
{
    public class PhonePlanRepository
    {
        private readonly DataContext _dataContext;
        public PhonePlanRepository() { }

        public PhonePlanRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual IEnumerable<PhonePlan> GetAll()
        {
            return _dataContext.PhonePlans.Include(x => x.DDDs).AsEnumerable();
        }

        public virtual Task<PhonePlan> GetById(int id)
        {
            return _dataContext.PhonePlans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task Post(PhonePlan phonePlan)
        {
            _dataContext.PhonePlans.Add(phonePlan);
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task Update(PhonePlan phonePlan)
        {
            _dataContext.PhonePlans.Update(phonePlan);
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(PhonePlan phonePlan)
        {
            _dataContext.PhonePlans.Remove(phonePlan);

            await _dataContext.SaveChangesAsync();
        }

        public virtual IEnumerable<PhonePlan> GetAllByDDD(int ddd)
        {
            return _dataContext.PhonePlans.Include(x => x.DDDs).Where(x => x.DDDs.Any(y => y.IdDDD == ddd)).AsEnumerable();
        }
    }
}