using AutoMapper;
using GA.UniCard.Application.CustomExceptions;
using GA.UniCard.Application.FluentValidates;
using GA.UniCard.Application.Interfaces;
using GA.UniCard.Application.Models;
using GA.UniCard.Application.StatickFiles;
using GA.UniCard.Domain.Entities;
using GA.UniCard.Domain.Interfaces;

namespace GA.UniCard.Application.Services
{
    /// <summary>
    /// Service class for managing operations related to products.
    /// </summary>
    public class ProductServices : AbstractService, IproductServices
    {
        private readonly ProductDtoValidations _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductServices"/> class with required dependencies.
        /// </summary>
        /// <param name="mapper">The AutoMapper instance for object mapping.</param>
        /// <param name="work">The unit of work instance for data operations.</param>
        public ProductServices(IMapper mapper, IUnitOfWork work) : base(mapper, work)
        {
            _validator = new ProductDtoValidations();
        }

        /// <summary>
        /// Adds a new product asynchronously.
        /// </summary>
        /// <param name="product">The product DTO to add.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> AddAsync(ProductDto product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var mappedProduct = mapper.Map<Product>(product) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            var result = await work.ProductRepository.AddAsync(mappedProduct);
            if (result > 0)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsuccesfullInsert);
        }

        /// <summary>
        /// Deletes a product asynchronously.
        /// </summary>
        /// <param name="productId">The ID of the product to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> DeleteAsync(long productId)
        {
            if (productId < 0)
            {
                throw new UniCardGeneralException(ErrorKeys.InternalServerError);
            }

            var result = await work.ProductRepository.DeleteAsync(productId);
            if (result)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves all products asynchronously.
        /// </summary>
        /// <returns>A collection of product DTOs.</returns>
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await work.ProductRepository.GetAllAsync();
            if (!products.Any())
            {
                throw new ItemNotFoundException(ErrorKeys.NoProduct);
            }

            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            if (productsDto == null)
            {
                throw new UniCardGeneralException(ErrorKeys.Mapped);
            }

            return productsDto;
        }

        /// <summary>
        /// Retrieves a product by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product DTO if found, otherwise throws an exception.</returns>
        public async Task<ProductDto> GetByIdAsync(long id)
        {
            var product = await work.ProductRepository.GetByIdAsync(id) ??
                throw new ItemNotFoundException(ErrorKeys.NoProduct);

            var productDto = mapper.Map<ProductDto>(product) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            return productDto;
        }

        /// <summary>
        /// Updates an existing product asynchronously.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The updated product DTO.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        public async Task<bool> UpdateAsync(long id, ProductDto product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                throw new UniCardGeneralException(validationResult.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var mappedProduct = mapper.Map<Product>(product) ??
                throw new UniCardGeneralException(ErrorKeys.Mapped);

            var result = await work.ProductRepository.UpdateAsync(id, mappedProduct);
            if (result)
            {
                return true;
            }

            throw new CompileTImeException(ErrorKeys.UnsucessfullUpdate);
        }
    }
}
