using Netflix.Model.Models;
using Netflix.Model.Request;
using Netflix.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netflix.Service.Interface
{
    public interface IUserService
    {
        UserResponse<Users> Retrieveuser(int page,int pageSize);
        int SaveUser(UsersRequest request);

        DeleteResponse DeleteUser(int id);

        EditResponse EditUser(int id);

        EditPostResponse Edited(Users Users);
        
    }
}
