﻿using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class KeywordRepository : GenericRepository<IProductContext, Keyword>, IKeywordInterface
    {
        
        public KeywordRepository(IUnitOfWork<IProductContext> uow) : base(uow)
        {
           
        }
    }
}
