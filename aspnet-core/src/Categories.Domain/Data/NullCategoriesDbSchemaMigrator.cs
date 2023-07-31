using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Categories.Data;

/* This is used if database provider does't define
 * ICategoriesDbSchemaMigrator implementation.
 */
public class NullCategoriesDbSchemaMigrator : ICategoriesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
