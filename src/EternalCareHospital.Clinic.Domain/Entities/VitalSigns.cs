using EternalCareHospital.SharedKernel;

namespace EternalCareHospital.Clinic.Domain.Entities
{
    public class VitalSigns : Entity
    {
        public VitalSigns(DateTime readingDateTime, decimal temperature, int heartRate, int respiratoryRate)
        {
            ReadingDateTime = readingDateTime;
            Temperature = temperature;
            HeartRate = heartRate;
            RespiratoryRate = respiratoryRate;
        }

        public VitalSigns()
        {
            
        }

        public DateTime ReadingDateTime { get; init; }
        public decimal Temperature { get; init; }
        public int HeartRate { get; init; }
        public int RespiratoryRate { get; init; }
    }
}
