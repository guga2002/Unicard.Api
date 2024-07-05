using AutoMapper;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    /// <summary>
    /// Abstract base class for services providing common dependencies.
    /// </summary>
    public abstract class AbstractService
    {
        protected readonly IMapper mapper;  // Mapper instance for mapping between DTOs and entities
        protected readonly IUnitOfWork work;  // Unit of work instance for managing data operations

        /// <summary>
        /// Constructs an instance of AbstractService with required dependencies.
        /// </summary>
        /// <param name="mapper">Instance of IMapper for object mapping.</param>
        /// <param name="work">Instance of IUnitOfWork for data operations.</param>
        protected AbstractService(IMapper mapper, IUnitOfWork work)
        {
            this.mapper = mapper;
            this.work = work;
        }
    }
}
