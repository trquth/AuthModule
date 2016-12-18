using System;

namespace Auth.Core.Interfaces.Services
{
    public interface IUserService
    {
        Guid Authenticate(string userName, string password);
    }
}
