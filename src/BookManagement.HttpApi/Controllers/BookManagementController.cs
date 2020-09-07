using BookManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class BookManagementController : AbpController
    {
        protected BookManagementController()
        {
            LocalizationResource = typeof(BookManagementResource);
        }
    }
}