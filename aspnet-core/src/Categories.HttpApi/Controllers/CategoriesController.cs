using Categories.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Categories.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CategoriesController : AbpControllerBase
{
    protected CategoriesController()
    {
        LocalizationResource = typeof(CategoriesResource);
    }
}
