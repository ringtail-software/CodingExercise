using System.Runtime.CompilerServices;

// expose assembly internals to the testing project
[assembly: InternalsVisibleTo("TradingApp.PerformanceApi.Tests")]

namespace TradingApp.PerformanceApi
{
    /// <summary>
    /// This class only exists to expose internals to the assocated test assemblies.
    /// </summary>
    public class AssemblyInfo
    {
    }
}
