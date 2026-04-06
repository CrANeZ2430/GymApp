namespace GymApp.Api.Repositories.UnitOfWork;

public interface IUnitOfWorkRepository
{
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
