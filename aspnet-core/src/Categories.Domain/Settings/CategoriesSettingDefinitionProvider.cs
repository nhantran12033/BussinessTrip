using Volo.Abp.Settings;

namespace Categories.Settings;

public class CategoriesSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CategoriesSettings.MySetting1));
    }
}
