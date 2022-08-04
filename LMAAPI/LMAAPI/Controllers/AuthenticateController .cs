using LMAAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMAAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly LmaApiContext _context;
        public  AuthenticateController (LmaApiContext context)
        {
            _context = context;


        }
        // GET: api/<AuthenticateController>
        [HttpGet]
        public IEnumerable<Login> Get()
        {
            return _context.Logins.ToList();
        }

        // GET api/<AuthenticateController>/5
        [HttpGet("{username}")]
        public Login Get(string username)
        {
            return _context.Logins.Where(login=>login.Username==username).FirstOrDefault();
        }

        // POST api/<AuthenticateController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthenticateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
