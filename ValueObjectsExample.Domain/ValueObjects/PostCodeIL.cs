using System;
using System.Collections.Generic;

namespace ValueObjectsExample.Domain.ValueObjects
{
    public class PostCodeIL : ValueObject
    {
        private int Code { get; }
        
        private PostCodeIL(int code) 
        {
            if (code < 0)
                throw new Exception("PostCodeIL must be positive number");

            if (code.ToString().Length < 7 || code.ToString().Length > 7)
                throw new Exception("Israel Postcode must be 7 digit long.");
            Code = code;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        public override bool Equals(object obj) => base.Equals(obj);
        protected bool Equals(PostCodeIL other) => Code == other.Code;

        public static bool operator ==(PostCodeIL left, PostCodeIL right)
        {
            if (left is null)
                return right is null;

            return left.Equals(right);
        }

        public static bool operator !=(PostCodeIL left, PostCodeIL right) => (left == right) is false;

        public override int GetHashCode() => base.GetHashCode();

        public static implicit operator PostCodeIL(int code) => new(code);

        public static implicit operator int(PostCodeIL postCodeIL) => postCodeIL.Code;
    }
}
