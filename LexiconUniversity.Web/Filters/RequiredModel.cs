﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LexiconUniversity.Web.Filters
{
    public class RequiredModel : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if(context.Result is ViewResult viewResult)
            {
                if(viewResult.Model is null)
                {
                    context.Result = new NotFoundResult(); 
                }
            }
        }
    }
}
