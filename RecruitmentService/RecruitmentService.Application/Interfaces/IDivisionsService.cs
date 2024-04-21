namespace RecruitmentService.Application.Interfaces
{
    public interface IDivisionsService
    {
        public Task CreateAsync(
            Guid divisionId,
            Guid companyId,
            Guid leadId,
            CancellationToken cancellationToken = default);

        public Task DeleteAsync(
            Guid divisionId,
            CancellationToken cancellationToken = default);
    }
}