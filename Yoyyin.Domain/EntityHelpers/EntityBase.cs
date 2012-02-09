namespace Yoyyin.Domain.EntityHelpers
{
    public interface IEntityBase
    {
        YoyyinEntities1 Entities { get; set; }
    }

    public abstract class EntityBase : IEntityBase
    {
        public YoyyinEntities1 Entities { get; set; }

        protected EntityBase()
        {
            Entities = new YoyyinEntities1();
        }

        ~EntityBase()
        {
            Entities.Dispose();
        }
    }
}
