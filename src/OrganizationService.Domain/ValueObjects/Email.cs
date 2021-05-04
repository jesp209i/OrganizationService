using System;
using System.Collections.Generic;
using System.Text;

namespace OrganizationService.Domain.ValueObjects
{
    public class Email
    {
        private string email;
        public string ActualEmail { 
            get => email;
            private set 
            {
                if (value.Contains("@") == false || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{typeof(Email)} requires a valid email");
                email = value.ToLowerInvariant();
            } 
        }
        public Email(string email)
        {
            ActualEmail = email;
        }

        public static implicit operator string(Email self) => self.ActualEmail;
    }
}
