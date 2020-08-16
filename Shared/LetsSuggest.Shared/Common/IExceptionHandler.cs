using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Framework.Common
{
    interface IExceptionHandler : IFilterMetadata
    {

        void OnException(ExceptionContext context);

    }
}
