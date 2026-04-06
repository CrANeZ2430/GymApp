using GymApp.Api.Database;

namespace GymApp.Api.Repositories.UnitOfWork;

public class UnitOfWorkRepository(GymAppDbContext dbContext) : IUnitOfWorkRepository
{
    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await dbContext.SaveChangesAsync(ct);
    }
}
