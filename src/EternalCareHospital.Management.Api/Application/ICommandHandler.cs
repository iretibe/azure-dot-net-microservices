namespace EternalCareHospital.Management.Api.Application
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
