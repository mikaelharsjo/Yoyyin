using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yoyyin.Model;
using Yoyyin.Model.Users;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.Commands;

namespace Yoyyin.Mvc.Controllers.Api
{
    public class UserController : ApiController
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET /api/<controller>
        public IEnumerable<IUser> Get()
        {
            return _repository.Query(m => m.Users);
        }

        // GET /api/<controller>/5
        public IUser Get(Guid id)
        {
            return _repository.Query(m => m.Users.First(u => u.UserId == id));
        }

        // POST /api/<controller>
        public HttpResponseMessage<IUser> Post(IUser user)
        {
            _repository.Execute(new AddUserCommand((User)user));

            var response = new HttpResponseMessage<IUser>(user, HttpStatusCode.Created);
            string uri = Url.Route(null, new { id = user.UserId });
            response.Headers.Location = new Uri(Request.RequestUri, uri);
            return response;
        }

        // PUT /api/<controller>/5
        public void Put(int id, IUser user)
        {
            //user.UserId = id;
            _repository.Execute(new UpdateUserCommand((User) user));
        }

        // DELETE /api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}