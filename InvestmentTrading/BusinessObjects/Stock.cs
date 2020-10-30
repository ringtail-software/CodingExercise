using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    /// <summary>
    /// Investment stock class
    /// </summary>
    public class Stock
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Stock()
        { }

        public Stock(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

    }
}
