using System;

namespace CodingExercise.Models
{
    public class Link
    {
        public string Href { get; }
        public string Rel { get; }
        public string Method { get; }
        public Link() : this("", "", "")
        {
        }
        public Link(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Link))
                return false;
            var val = (Link)obj;
            return Href == val.Href && Rel == val.Rel && Method == val.Method;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Href, Rel, Method);
        }
    }
}
