using Categories.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Categories;

[DependsOn(
    typeof(CategoriesEntityFrameworkCoreTestModule)
    )]
public class CategoriesDomainTestModule : AbpModule
{

}
