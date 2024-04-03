using EmployeeService.Models.Entities;
using System.Linq.Expressions;

namespace EmployeeService.Persistence.Repositories.Interfaces
{
    public interface IUnitsRepository
    {
        public Task<IEnumerable<Unit>> GetUnitsAsync(
            Expression<Func<Unit, bool>> condition,
            CancellationToken cancellationToken = default);

        public Task<Unit> GetUnitAsync(
            Expression<Func<Unit, bool>> condition,
            CancellationToken cancellationToken = default);

        public Task AddUnitAsync(
            Unit unit,
            CancellationToken cancellationToken = default);

        public Task DeleteAsync(
            Guid unitId,
            CancellationToken cancellationToken = default);

        public Task UpdateRangeAsync(
            CancellationToken cancellationToken,
            params Unit[] units);
    }
}
