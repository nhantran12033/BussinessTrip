using Volo.Abp.Modularity;

namespace Categories;

[DependsOn(
    typeof(CategoriesApplicationModule),
    typeof(CategoriesDomainTestModule)
    )]
public class CategoriesApplicationTestModule : AbpModule
{

}
