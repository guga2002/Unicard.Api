using AutoMapper;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    public abstract class AbstractService
    {
        protected readonly IMapper mapper;

        protected readonly IUniteOfWork work;

        protected AbstractService(IMapper mapper, IUniteOfWork work)
        {
            this.mapper = mapper;
            this.work = work;
        }
    }
}
