using System;
using System.Collections.Generic;
using System.Linq;
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
      
        private readonly ILogger<MemberController> _logger;
        private readonly IMemberRepository _memberRepository;
        public MemberController(ILogger<MemberController> logger, IMemberRepository memberRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
        }

        //[HttpGet]
        //public IEnumerable<Member> Get()
        //{
        //    var members = _memberRepository.GetMembers();
        //    return members;
        //}

        [HttpGet("{MemberId}", Name = "Get")]
        public Member Get(int MemberId)
        {
            var member = _memberRepository.GetMemberByID(MemberId);
            return member;
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
                        return new OkResult();
                    }
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(404);

            }
            return new NoContentResult();
        }
    }
}
