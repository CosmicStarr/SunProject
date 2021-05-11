using AutoMapper;
using Infrastructure.Models;
using Microsoft.Extensions.Configuration;
using SunProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunProject.Mapper
{
    public class ProductsResolver : IValueResolver<Products, ProductsDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductsResolver(IConfiguration Config)
        {
            _config = Config;
        }
        public string Resolve(Products source, ProductsDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ImageUrl))
            {
                return _config["APIURL"] + source.ImageUrl;
            }
            return null;
        }
    }
}
