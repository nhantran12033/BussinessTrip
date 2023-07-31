using Categories.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Categories.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CategoriesEntityFrameworkCoreModule),
    typeof(CategoriesApplicationContractsModule)
    )]
public class CategoriesDbMigratorModule : AbpModule
{
}
