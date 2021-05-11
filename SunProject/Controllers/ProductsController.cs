using AutoMapper;
using Core;
using Core.Data.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunProject.DTO;
using SunProject.Errors;
using SunProject.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunProject.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Products> _productsRepo;
        private readonly IGenericRepository<ProductsBrand> _productBrandRepo;
        private readonly IGenericRepository<Category> _category;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Products> productsRepo, IGenericRepository<ProductsBrand> productBrandRepo, IGenericRepository<Category> Category, IMapper mapper)
        {
            _mapper = mapper;

            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
            _category = Category;

        }

        [HttpGet]
        public async Task<ActionResult<PagiNation<ProductsDTO>>> GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var Spec = new ProductsWithBrandsandCatSpecs(specParams);
            var CountSpec = new ProductsWithFiltersCountSpecifications(specParams);
            var TotalItems = await _productsRepo.CountAsync(CountSpec);
            var Products = await _productsRepo.ListAsync(Spec);
            var Data = _mapper.Map<IReadOnlyList<Products>, IReadOnlyList<ProductsDTO>>(Products);
            return Ok(new PagiNation<ProductsDTO>(specParams.PageIndex, specParams.PageSize, TotalItems, Data));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductsDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithBrandsandCatSpecs(id);

            var product = await _productsRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Products, ProductsDTO>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductsBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }
        [HttpGet("category")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetProductTypes()
        {
            return Ok(await _category.ListAllAsync());
        }
    }
}
