using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.Repositories
{
    public abstract class AbstractRepository
    {
        protected readonly string ConnectionString;
        private readonly IConfiguration Config;
        protected AbstractRepository(IConfiguration conf)
        {
            this.Config = conf;
            Config = Config ?? throw new ArgumentNullException(nameof(Config));
            ConnectionString = Config.GetConnectionString("DapperConnection")
                                ?? throw new InvalidOperationException("Connection string not found");
        }
    }
}
