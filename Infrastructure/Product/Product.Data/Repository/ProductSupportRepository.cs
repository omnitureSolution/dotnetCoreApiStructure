﻿using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class ProductSupportRepository : GenericRepository<IProductContext, ProductSupport>, IProductSupportInterface
    {
        
        public ProductSupportRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }
    }
}
