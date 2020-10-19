using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQY_Microservice.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberByID(int MemberId);
        void UpdateMember(Member member);
        void Save();
    }
}
