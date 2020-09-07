using Volo.Abp.Settings;

namespace BookManagement.Settings
{
    public class BookManagementSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(BookManagementSettings.MySetting1));
        }
    }
}
