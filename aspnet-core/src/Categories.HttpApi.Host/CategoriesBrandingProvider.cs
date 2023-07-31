using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Categories;

[Dependency(ReplaceServices = true)]
public class CategoriesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Categories";
}
