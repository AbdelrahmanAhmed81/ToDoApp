namespace ToDo.Domain.Contracts
{
    internal interface IBaseEntity
    {
        DateTime CreationDate { get; set; }
        DateTime LastModificationDate { get; set; }
        bool IsDeleted { get; set; }
    }
}
