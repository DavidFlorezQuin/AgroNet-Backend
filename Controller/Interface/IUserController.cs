using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller.Interface
{
    public interface  IUserController
    {
        public Task<ActionResult> Post([FromBody] UserDto user); 
        public Task<ActionResult> Put(int id, [FromBody] UserDto user);
        public Task<ActionResult> Delete(int id);

    }
}
