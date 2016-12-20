using Auth.Core.Interfaces.Services;
using Auth.Data.UnitOfWork;
using System;

namespace Auth.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork _unitOfWork;
        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Guid Authenticate(string userName, string password)
        {
            var user = _unitOfWork.UserRepository.SingleBy(u => u.Username == userName && u.Password == password);
            if (user != null)
            {
                return user.Id;
            }
            return Guid.Empty;
        }
    }
}
