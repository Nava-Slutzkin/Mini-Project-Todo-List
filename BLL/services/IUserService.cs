using DAL.Data;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IUserService
    {
        Users AddUser(Users user);
        Users? GetUserById(int id);
        List<Users> GetUsersList();
    }
}