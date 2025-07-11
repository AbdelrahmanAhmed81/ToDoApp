namespace ToDo.Domain.Common
{
    public abstract class BaseEntityIdentified : BaseEntity
    {
        public Guid ID { get; set; }

    }
}
