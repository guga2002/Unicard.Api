using System;
using Microsoft.Extensions.Configuration;

namespace GA.UniCard.Infrastructure.Repositories
{
    /// <summary>
    /// Base class for repositories providing access to configuration settings and connection string.
    /// </summary>
    public abstract class AbstractRepository
    {
        protected readonly string ConnectionString;
        private readonly IConfiguration Config;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractRepository"/> class.
        /// </summary>
        /// <param name="conf">The configuration instance to retrieve settings from.</param>
        protected AbstractRepository(IConfiguration conf)
        {
            this.Config = conf ?? throw new ArgumentNullException(nameof(conf));
            ConnectionString = Config.GetConnectionString("DapperConnection")
                                ?? throw new InvalidOperationException("Connection string not found");
        }
    }
}
