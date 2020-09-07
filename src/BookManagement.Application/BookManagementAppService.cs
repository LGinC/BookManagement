using System;
using System.Collections.Generic;
using System.Text;
using BookManagement.Localization;
using Volo.Abp.Application.Services;

namespace BookManagement
{
    /* Inherit your application services from this class.
     */
    public abstract class BookManagementAppService : ApplicationService
    {
        protected BookManagementAppService()
        {
            LocalizationResource = typeof(BookManagementResource);
        }
    }
}
