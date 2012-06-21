using System.Collections.Generic;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Importers
{
    public interface ISniImporter
    {
        IEnumerable<Sni> Import();
    }
}