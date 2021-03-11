using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.Models
{
    public class LinkCollectionWrapper<T> : LinkedResource
    {
        public IEnumerable<T> Values { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is LinkCollectionWrapper<T>))
                return false;
            var val = (LinkCollectionWrapper<T>)obj;

            return Values.SequenceEqual(val.Values) && Links.Equals(val.Links);
        }

        public LinkCollectionWrapper(){}

        public override int GetHashCode()
        {
            return HashCode.Combine(Values, Links);
        }
    }
}
