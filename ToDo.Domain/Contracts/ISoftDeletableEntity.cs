namespace ToDo.Domain.Contracts
{
    internal interface ISoftDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTime DeletionDate { get; set; }
    }
}
