using AuthDB.Entities.Enums;

namespace AuthLogic;

public static class RoleHelper 
{
    private static readonly Dictionary<RoleEnum, PremissionsEnum[]> premissions = new()
    {
        // Admin
        // Админу будут доступны вообще всевозможные роли
        { RoleEnum.Admin, new[]
        {PremissionsEnum.UsersView, PremissionsEnum.Default } },
        { RoleEnum.User, new[]
        {PremissionsEnum.Default } },
    };

    public static PremissionsEnum[] GetPermissions(RoleEnum role)
    {
        return premissions.GetValueOrDefault(role, Array.Empty<PremissionsEnum>());
    }

}
