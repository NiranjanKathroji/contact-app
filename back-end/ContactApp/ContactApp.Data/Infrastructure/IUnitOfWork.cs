namespace ContactApp.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
