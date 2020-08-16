using System;
using System.Collections.Generic;
using System.Text;
using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class BusinessRepository : GenericRepository<IProductContext, Business>, IBusiness
    {
        public BusinessRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {

        }
    }
}
