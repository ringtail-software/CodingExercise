using Nuix.Data.Model;
using System.Collections.Generic;

namespace Nuix.Data.Repository.MoqData
{
    public interface IData
    {
        Dictionary<string, IEnumerable<Investment>> ClientFactory();
    }
}
