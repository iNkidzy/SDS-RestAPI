using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDS.Core.AplicationService;
using SDS.Core.Entity;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sdsconController : ControllerBase
    {
        private readonly IAvatarService _avatarService;

        public sdsconController(IAvatarService avatarService)
        {

            _avatarService = avatarService;
        }

        // GET: api/sdscon
        [HttpGet]
        public IEnumerable<Avatar> Get()
        {
            return _avatarService.GetAvatars();
        }

        // GET: api/sdscon/5
        [HttpGet("{id}", Name = "Get")]
        public Avatar Get(int id)
        {
            return _avatarService.FindAvatarById(id);
        }

        // POST: api/sdscon
        //[ProduceResponseType](typeof


        [HttpPost]
        public void Post([FromBody] Avatar avatar)
        {
            _avatarService.Create(avatar);
        }

        // PUT: api/sdscon/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Avatar avatar)
        {
            _avatarService.UpdateAvatar(avatar);
        }
        //nnfnf
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             _avatarService.DeleteAvatar(id);
        }
    }
        
}


