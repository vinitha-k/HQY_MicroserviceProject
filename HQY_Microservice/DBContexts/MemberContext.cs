using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HQY_Microservice.DBContexts
{
    public class MemberContext : DbContext
    {
        public MemberContext(DbContextOptions<MemberContext> options) : base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
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
            );
        }
    }
}
