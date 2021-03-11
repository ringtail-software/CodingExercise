using System;
using System.Linq;

namespace CodingExercise.Models
{
    public class Investment : LinkedResource
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Investment()
        {

        }
        public override bool Equals(object obj)
        {
            if (!(obj is Investment))
                return false;
            var val = (Investment)obj;
            return Id == val.Id && Name == val.Name && Links.Equals(val.Links);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Links);
        }
    }
}
