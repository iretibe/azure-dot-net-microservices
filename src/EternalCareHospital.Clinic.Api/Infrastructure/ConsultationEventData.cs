namespace EternalCareHospital.Clinic.Api.Infrastructure
{
    public record ConsultationEventData(Guid Id, string AggregateId, 
        string EventName, string Data, string AssemblyQualifiedName);
}