using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Services
{
    public interface ITokenService
    {
        string GenerateToken(int userId, string userName, string email);
    }
}
