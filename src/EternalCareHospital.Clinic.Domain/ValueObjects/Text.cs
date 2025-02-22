﻿namespace EternalCareHospital.Clinic.Domain.ValueObjects
{
    public record Text
    {
        public string Value { get; init; }

        public Text(string value)
        {
            Validate(value);

            Value = value;
        }

        private void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("value", "Text is not valid!");
            }

            if (value.Length > 500)
            {
                throw new ArgumentException("Text is too large!");
            }
        }

        public static implicit operator Text(string value)
        {
            return new Text(value);
        }

        public static implicit operator string(Text value)
        {
            return value.Value;
        }
    }
}
