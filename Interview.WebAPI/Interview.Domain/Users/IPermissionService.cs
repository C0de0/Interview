namespace Interview.Domain.Users
{
    public interface IPermissionService
    {
        bool IsAllowed(Permission permission, User user);
    }

}
