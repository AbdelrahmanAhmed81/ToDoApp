namespace ToDo.Domain.Contracts
{
    internal interface IAuditableEntity
    {
        DateTime CreationDate { get; set; }
        DateTime LastModificationDate { get; set; }
    }
}
