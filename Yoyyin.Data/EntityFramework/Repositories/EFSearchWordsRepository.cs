using System.Data.Objects;
using System.Linq;

namespace Yoyyin.Data.EntityFramework
{
    public class EFSearchWordsRepository: IEntityWordsRepository
    {
        private YoyyinEntities1 _entities;

        public EFSearchWordsRepository(YoyyinEntities1 entities)
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