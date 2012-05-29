using System.Collections.Generic;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Importing
{
    public interface ISniImporter
    {
        IEnumerable<Sni> Import();
    }
}