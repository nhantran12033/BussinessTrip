using System.Threading.Tasks;

namespace Categories.Data;

public interface ICategoriesDbSchemaMigrator
{
    Task MigrateAsync();
}
