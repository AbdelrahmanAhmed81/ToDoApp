namespace ToDo.Application.Common
{
    public abstract class UserRequest
    {
        public Guid RequestSenderUserId { get; set; }
    }
}
