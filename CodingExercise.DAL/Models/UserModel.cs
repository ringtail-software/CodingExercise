using System.Collections.Generic;

namespace CodingExercise.DAL.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<InvestmentModel> Investments { get; set;  }

        public override bool Equals(object obj)
        {
            if (!(obj is UserModel))
                return false;
            var val = (UserModel)obj;
            return Id == val.Id && Name == val.Name && Investments.Equals(val.Investments);
        }
    }
}
