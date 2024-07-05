namespace GA.UniCard.Infrastructure.Repositories
{
    public abstract class AbstractRepository
    {
        protected readonly string ConnectionString;
        protected AbstractRepository(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }
    }
}
