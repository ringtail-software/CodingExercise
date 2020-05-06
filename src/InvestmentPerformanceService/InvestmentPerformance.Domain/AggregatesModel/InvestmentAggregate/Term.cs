using System;
using System.Collections.Generic;
using System.Linq;
using InvestmentPerformance.Domain.SeedWork;

namespace InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate
{
    public class Term : Enumeration
    {
        public static Term Short = new Term(1, nameof(Short).ToLowerInvariant());
        public static Term Long = new Term(2, nameof(Long).ToLowerInvariant());

        public Term(int id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<Term> List() => new[] { Short, Long };

        public static Term FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new Exception($"Possible values for Term: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static Term From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new Exception($"Possible values for Term: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
