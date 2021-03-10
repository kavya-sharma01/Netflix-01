using Netflix.Data.Interface;
using Netflix.Model.Models;
using Netflix.Model.Request;
using Netflix.Model.Response;
using Netflix.Service.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.Service.Implementation
{
    public class UserService : IUserService
    {
        string password;
        private INetflixDbContext _netflixdbcontext;

        public UserService(INetflixDbContext netflixdbcontext)
        {
            _netflixdbcontext = netflixdbcontext;
        }

        public UserResponse<Users> Retrieveuser(int page,int pageSize)
        {
            var outputdata = new UserResponse<Users>
            {
                Totalpage = _netflixdbcontext.Users.Count(),
                Currentpage = page,
                pagesize = pageSize,
                Data = _netflixdbcontext.Users.ToList(),

            };
           
            return outputdata;
        }
        public int SaveUser(UsersRequest request)
        {
            password = encryptpass(request);
            Users demo = new Users()
            {
                firstname = request.firstname,
                email = request.email,
                ps = request.ps,
                no = request.no,
                course = request.course,
                checkbox = request.checkbox,
                

            };
            _netflixdbcontext.Users.Add(demo);
            _netflixdbcontext.SaveChanges();

            return demo.id;
        }

        public string encryptpass(UsersRequest request)
        {
            string msg = "";
            byte[] encode = new byte[request.ps.Length];
            encode = Encoding.UTF8.GetBytes(request.ps);
            msg = Convert.ToBase64String(encode);
            return msg;
        }

        public DeleteResponse DeleteUser(int id)
        {
            var Users = _netflixdbcontext.Users.Where(o => o.id == id).FirstOrDefault();
            if (Users == null)
            {
                return new DeleteResponse { Errormessage = $"User with Id={id} canot be found" };
            }

            var result = _netflixdbcontext.Users.Remove(Users);

            _netflixdbcontext.SaveChanges();
            return new DeleteResponse { Errormessage = "user is  Deleted successfully", deleted = true };


        }

        public EditResponse EditUser(int id)
        {
            var Users = _netflixdbcontext.Users.Where(o => o.id == id).FirstOrDefault();

            var userlist = new EditResponse
            {
                id = Users.id,
                firstname = Users.firstname,
                email = Users.email,
                ps = Users.ps,
                no = Users.no,
                course = Users.course,
                checkbox = Users.checkbox,
            };
            return userlist;
        }

        public EditPostResponse Edited(Users Users)
        {
            var student = _netflixdbcontext.Users.Where(o => o.id == Users.id).FirstOrDefault();
           var result= _netflixdbcontext.Users.Remove(student);
            _netflixdbcontext.Users.Add(Users);
            _netflixdbcontext.SaveChanges();
            return new EditPostResponse { edited = true, message = "user has been edited successfully"} ;
        }
    }
}
