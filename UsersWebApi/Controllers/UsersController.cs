using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersWebApi.Intefaces;

namespace UsersWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase, ICRUDContoller<User>
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(ILogger<UsersController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void Create(User user)
        {
            _unitOfWork.Users.Create(user);
        }

        [HttpGet]
        [HttpPost]
        public void Delete(int id)
        {
            _unitOfWork.Users.Delete(id);
        }

        [HttpGet]
        [HttpPost]
        public User Get(int id)
        {
            return _unitOfWork.Users.Get(id);
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.Users.GetAll();
        }

        [HttpPost]
        public void Update(User user)
        {
            _unitOfWork.Users.Update(user);
        }
    }
}
