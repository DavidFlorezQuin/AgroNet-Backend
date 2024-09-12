using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using Controller.Interface;
using Data.Dto;
using Entity.Model.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




namespace Controller.Implementation
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : IUserController
    {
        private readonly IUserBusiness business;

        public UsersController(IUserBusiness business)
        {
            this.business = business;
        }

        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> Post([FromBody] UserDto user)
        {
            try
            {
                User users = await business.Save(user);
                var response = new ApiRes
            }
        }

        public Task<ActionResult> Put(int id, [FromBody] UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
