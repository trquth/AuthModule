using Auth.Core.Interfaces.Services;
using Auth.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var user = _unitOfWork.UserRepository.Get(u => u.Username == userName && u.Password == password);
            if (user != null)
            {
                return user.Id;
            }
            return Guid.Empty;
        }
    }
}
