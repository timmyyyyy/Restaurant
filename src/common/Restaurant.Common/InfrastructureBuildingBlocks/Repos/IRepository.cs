namespace Restaurant.Common.InfrastructureBuildingBlocks.Repos
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
