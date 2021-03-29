using System;
using System.Collections.Generic;
using System.Text;

namespace NuixInvestments.MiddleWare.Data.POCO
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public byte[] Password { get; set; }
    }
}
