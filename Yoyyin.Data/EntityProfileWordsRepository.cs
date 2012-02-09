using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace Yoyyin.Data
{
    public class EntityProfileWordsRepository : IEntityWordsRepository
    {
        private YoyyinEntities1 _entities;

        public EntityProfileWordsRepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

        public IQueryable Find()
        {
            return _entities
                        .ExecuteFunction<string>("usp_AutoComplete_Get", new ObjectParameter[0])
                        .AsQueryable();
        }
    }
}
