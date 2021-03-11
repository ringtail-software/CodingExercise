using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.Models
{
    public class LinkedResource
    {
        public LinkedResource()
        {

        }
        public List<Link> Links { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is LinkedResource))
                return false;
            var val = (LinkedResource)obj;
            return Links.Equals(val.Links);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Links);
        }
    }
}
