using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using HQY_Microservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HQY_Microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]/contact")]
    public class MemberController : ControllerBase
    {
      
        private readonly ILoggingService _logger;
        private readonly IMemberRepository _memberRepository;
        public MemberController(ILoggingService logger, IMemberRepository memberRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
         
            var members = _memberRepository.GetMembers();
            _logger.LogInformation("Retrieved {count} members", members.Count());
            return Ok(members);
        }      

        [HttpGet("{MemberId}", Name = "Get")]
        public IActionResult GetById(int MemberId)
        {
            var member = _memberRepository.GetMemberByID(MemberId);   
            if(member == null)
            {
                _logger.LogInformation("Unable to find member with Id : {Id}", MemberId);
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Member member)
        {
            try
            {

                if (member != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        _memberRepository.UpdateMember(member);
                        scope.Complete();
                        return Ok(member);
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.Message);
                return NotFound();

            }
            return new NoContentResult();
        }
    }
}
