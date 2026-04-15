using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Domain.ValueObjects
{

    public sealed class Email
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");

            if (!email.Contains("@"))
                throw new ArgumentException("Invalid email format.");

            return new Email(email.Trim().ToLower());
        }
        public override string ToString() => Value;

        public override bool Equals(object? obj)
            => obj is Email other && Value == other.Value;

        public override int GetHashCode()
            => Value.GetHashCode(

    }
}

