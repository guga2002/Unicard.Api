using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.FluentValidates;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using GA.UniCard.Domain.Entitites;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    public class ProductServices : AbstractService, IproductServices
    {
        private readonly ProductDtoValidations _validator;
        public ProductServices(IMapper mapper, IUniteOfWork work) : base(mapper, work)
        {
            _validator = new ProductDtoValidations();
        }

        public async Task<bool> AddAsync(ProductDto product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var Mappedproduct = mapper.Map<Product>(product) ??
                throw new UniCardGeneralException(ErrorKeys.mapped);

            var result = await work.ProductRepository.AddAsync(Mappedproduct);
            if (result > 0)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsuccesfullInsert);
        }

        public async Task<bool> DeleteAsync(long orderId)
        {
            if (orderId < 0)
            {
                throw new UniCardGeneralException(ErrorKeys.InternalServerError);
            }

            var result = await work.ProductRepository.DeleteAsync(orderId);
            if (result)
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var Products = await work.OrderRepository.GetAllAsync();
            if (!Products.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoProduct);
            }

            var ProductsDto = mapper.Map<IEnumerable<ProductDto>>(Products);
            if (ProductsDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.mapped);
            }

            return ProductsDto;
        }

        public async Task<ProductDto> GetByIdAsync(long Id)
        {
            var product = await work.ProductRepository.GetByIdAsync(Id) ??
                throw new ItemNotFoundException(ErrorKeys.NoProduct);
            var productDto = mapper.Map<ProductDto>(product) ??
                throw new UniCardGeneralException(ErrorKeys.mapped);
            return productDto;
        }

        public async Task<bool> UpdateAsync(long id, ProductDto product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var MappedProduct = mapper.Map<Product>(product) ??
                throw new UniCardGeneralException(ErrorKeys.mapped);

            var result = await work.ProductRepository.UpdateAsync(id, MappedProduct);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
