﻿namespace PCK.Utility
{
    public class Price : IComparable<Price>
    {
        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                if (value < 0.0)
                    throw new ArgumentException("Price can't be negative");
                _value = Math.Round(value, 4);
            }
        }
        public Price(double value) => Value = value;
        public Price(Price price) => Value = price.Value;
        public static Price operator +(Price p1, Price p2) => new(p1.Value + p2.Value);
        public static Price operator -(Price p1, Price p2) => new(p1.Value - p2.Value);
        public static Price operator /(Price p1, Price p2) => new(p1.Value / p2.Value);
        public static Price operator *(Price p1, Price p2) => new(p1.Value * p2.Value);
        public static bool operator ==(Price p1, Price p2) => p1.Value == p2.Value;
        public static bool operator !=(Price p1, Price p2) => p1.Value != p2.Value;
        public static bool operator <(Price p1, Price p2) => p1.Value < p2.Value;
        public static bool operator >(Price p1, Price p2) => p1.Value > p2.Value;
        public static bool operator >=(Price p1, Price p2) => p1.Value >= p2.Value;
        public static bool operator <=(Price p1, Price p2) => p1.Value <= p2.Value;
        public int CompareTo(Price? other)
        {
            if (other is null)
                return 1;
            return this.Value.CompareTo(other.Value);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return this == (Price)obj;
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
        public override string ToString()
        {
            // Using format specifier N2 to round to 2 decimal places.
            return Value.ToString("N2") + "$";
        }
    }
}
