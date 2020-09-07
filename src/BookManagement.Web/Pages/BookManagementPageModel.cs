using BookManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BookManagement.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class BookManagementPageModel : AbpPageModel
    {
        protected BookManagementPageModel()
        {
            LocalizationResourceType = typeof(BookManagementResource);
        }
    }
}