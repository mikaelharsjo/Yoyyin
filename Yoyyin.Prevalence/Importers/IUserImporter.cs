using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yoyyin.Model.Users.AggregateRoots;

namespace Yoyyin.Model.Importers
{
    public interface IUserImporter
    {
        IEnumerable<User> Import();
    }
}
