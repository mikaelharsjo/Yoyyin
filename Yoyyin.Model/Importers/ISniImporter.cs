using System.Collections.Generic;
using Yoyyin.Model.Users.AggregateRoots;
using Yoyyin.Model.Users.ValueObjects;

namespace Yoyyin.Model.Importers
{
    public interface ISniImporter
    {
        IEnumerable<SniHead> Import();
    }
}