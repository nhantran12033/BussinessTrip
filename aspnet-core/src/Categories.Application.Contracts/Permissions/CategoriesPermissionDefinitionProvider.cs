using Categories.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Categories.Permissions;

public class CategoriesPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(CategoriesPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(CategoriesPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CategoriesResource>(name);
    }
}
