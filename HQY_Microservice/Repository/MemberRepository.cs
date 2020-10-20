using HQY_Microservice.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQY_Microservice.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberContext _dbContext;
        public MemberRepository(MemberContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Member GetMemberByID(int MemberId)
        {
            return _dbContext.Members.Find(MemberId);
        }

        public IEnumerable<Member> GetMembers()
        {
            return _dbContext.Members.ToList();
        }

        public Member UpdateMember(Member member)
        {
            _dbContext.Entry(member).State = EntityState.Modified;
            Save();
            return member;
        }
        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
