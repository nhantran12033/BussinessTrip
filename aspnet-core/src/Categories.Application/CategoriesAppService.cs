using System;
using System.Collections.Generic;
using System.Text;
using Categories.Localization;
using Volo.Abp.Application.Services;

namespace Categories;

/* Inherit your application services from this class.
 */
public abstract class CategoriesAppService : ApplicationService
{
    protected CategoriesAppService()
    {
        LocalizationResource = typeof(CategoriesResource);
    }
}
