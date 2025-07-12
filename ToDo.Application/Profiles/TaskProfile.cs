using AutoMapper;
using ToDo.Application.DTOs;


namespace ToDo.Application.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskEntity, TaskDTO>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskDTO>().ReverseMap();
            CreateMap<TaskEntity, UpdateTaskDTO>().ReverseMap();
        }
    }
}
