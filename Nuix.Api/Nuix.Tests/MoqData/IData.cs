using Nuix.Data.Model;
using System.Collections.Generic;

namespace Nuix.Tests.MoqData
{
    public interface IData
    {
        Dictionary<string, IEnumerable<Investment>> ClientFactory();
    }
}
