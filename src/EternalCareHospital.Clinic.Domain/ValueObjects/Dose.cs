using EternalCareHospital.Clinic.Domain.Enums;

namespace EternalCareHospital.Clinic.Domain.ValueObjects
{
    public record Dose
    {
        public Dose(decimal quantity, UnitOfMeasure unit)
        {
            Quantity = quantity;
            Unit = unit;
        }

        public decimal Quantity { get; init; }
        public UnitOfMeasure Unit { get; init; }
    }
}
