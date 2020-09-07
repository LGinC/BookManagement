using BookManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookManagement.Permissions
{
    public class BookManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BookManagementPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(BookManagementPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BookManagementResource>(name);
        }
    }
}
