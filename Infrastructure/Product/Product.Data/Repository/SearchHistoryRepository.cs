﻿using LetsSuggest.Context;
using LetsSuggest.Product.Core;
using LetsSuggest.Product.Core.Interfaces;
using LetsSuggest.Product.Core.Model;

namespace LetsSuggest.Product.Data.Repository
{
    public class SearchHistoryRepository : GenericRepository<IProductContext, SearchHistory>, ISearchHistoryInterface
    {
        

        public SearchHistoryRepository(IUnitOfWork<IProductContext> uow):base(uow)
        {
           
        }

    }
}
