﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Budget.DataAccess;
using Budget.ObjectModel;

namespace Budget.WebApi.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IRepository<Product> repository;

        public ProductController(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<Product[]> GetAll()
        {
            return (await this.repository.ReadAll()).ToArray();
        }

        [HttpPut]
        public Task<Product> Insert([FromBody] Product product)
        {
            return this.repository.Save(product);
        }

        [HttpPost]
        public Task Update([FromBody] Product product)
        {
            return this.repository.Update(product);
        }

        [HttpDelete]
        public Task Delete([FromUri] int id)
        {
            Product product = new Product();
            product.Id = id;
         
            return this.repository.Remove(product);
        }
    }
}
