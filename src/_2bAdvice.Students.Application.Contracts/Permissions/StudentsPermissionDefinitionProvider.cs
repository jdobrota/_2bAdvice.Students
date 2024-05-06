using _2bAdvice.Students.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace _2bAdvice.Students.Permissions;

public class StudentsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(StudentsPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(StudentsPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<StudentsResource>(name);
    }
}
