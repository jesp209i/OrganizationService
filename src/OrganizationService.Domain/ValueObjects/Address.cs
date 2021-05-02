using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Domain.ValueObjects
{
    public class Address : IEquatable<Address>
    {
        public string Street { get; private set; }
        public string StreetExtended { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        
        public Address(string street, string streetExtended, string postalCode, string city, string country)
        {
            Guard(street, postalCode, city, country);
            Street = street;
            StreetExtended = streetExtended;
            PostalCode = postalCode;
            City = city;
            Country = country;
        }

        private void Guard(string street, string postalCode, string city, string country)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException($"{nameof(street)} cannot be an empty string");
            if (string.IsNullOrWhiteSpace(postalCode))
                throw new ArgumentException($"{nameof(postalCode)} cannot be an empty string");
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException($"{nameof(city)} cannot be an empty string");
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException($"{nameof(country)} cannot be an empty string");
        }

        public Address(string street, string postalCode, string city, string country)
            : this(street, string.Empty, postalCode, city, country) 
        { }

        public override bool Equals(object obj)
        {
            return Equals(obj as Address);
        }
        public bool Equals(Address other)
        {
            return other != null 
                && Street.Equals(other.Street)
                && StreetExtended.Equals(other.StreetExtended)
                && PostalCode.Equals(other.PostalCode)
                && City.Equals(other.City)
                && Country.Equals(other.Country);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, StreetExtended, PostalCode, City, Country);
        }
    }
}
