namespace ToDo.Domain.Common
{
    internal abstract class BaseEntityIdentified : BaseEntity
    {
        public Guid ID { get; set; }

    }
}
