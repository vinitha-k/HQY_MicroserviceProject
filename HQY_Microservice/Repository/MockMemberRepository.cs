using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQY_Microservice.Repository
{
    
    public class MockMemberRepository : IMemberRepository
    {
        private List<Member> _memberList;

        public MockMemberRepository()
        {
            _memberList = new List<Member>()
            {
                new Member
                {
                    MemberId = 1,
                    FirstName = "Mark",
                    LastName = "Wilson",
                    PhoneNumber = "916-346-7839",
                    Email = "mark.wilson@xyz.com"
                },
                new Member
                {
                    MemberId = 2,
                    FirstName = "Ted",
                    LastName = "Parker",
                    PhoneNumber = "916-326-7839",
                    Email = "ted.parker@xyz.com"
                },
                new Member
                {
                    MemberId = 3,
                    FirstName = "Lynn",
                    LastName = "Johnson",
                    PhoneNumber = "516-896-3439",
                    Email = "lynn.johnson@xyz.com"
                }
            };
        }
        public Member GetMemberByID(int MemberId)
        {
            return this._memberList.Find(e => e.MemberId == MemberId);
        }

        public IEnumerable<Member> GetMembers()
        {
            return _memberList;
        }


        public Member UpdateMember(Member member)
        {
            Member thismember = _memberList.FirstOrDefault(e => e.MemberId == member.MemberId);
            if(thismember != null)
            {
                thismember.FirstName = member.FirstName;
                thismember.LastName = member.LastName;
                thismember.PhoneNumber = member.PhoneNumber;
                thismember.Email = member.Email;
            }
            return thismember;
        }
    }
}
