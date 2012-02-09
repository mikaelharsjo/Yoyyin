using System.Data.Objects;
using System.Linq;

namespace Yoyyin.Data
{
    public class EntitySearchWordsRepository: IEntityWordsRepository
    {
        private YoyyinEntities1 _entities;

        public EntitySearchWordsRepository(YoyyinEntities1 entities)
        {
            _entities = entities;
        }

        public IQueryable Find()
        {
            return _entities
                .ExecuteFunction<string>("usp_SearchWords_GetAll", new ObjectParameter[0])
                .AsQueryable();
        }
    }
}