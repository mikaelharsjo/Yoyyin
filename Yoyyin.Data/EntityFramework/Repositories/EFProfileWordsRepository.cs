using System.Data.Objects;
using System.Linq;

namespace Yoyyin.Data.EntityFramework
{
    public class EFProfileWordsRepository : IEntityWordsRepository
    {
        private YoyyinEntities1 _entities;

        public EFProfileWordsRepository(YoyyinEntities1 entities)
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
