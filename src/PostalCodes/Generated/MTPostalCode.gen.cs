using System;
using System.Text.RegularExpressions;
using PostalCodes.GenericPostalCodes;

namespace PostalCodes
{
    internal partial class MTPostalCode : AlphaNumericPostalCode
    {
        public MTPostalCode(string postalCode) : this(postalCode, true) {}

        public MTPostalCode(string postalCode, bool allowConvertToShort) : base(_formats, postalCode, allowConvertToShort) 
        {
            _countryName = "Malta";
        }

        private MTPostalCode(PostalCode other) : base(_formats, other.ToString()) {}
        
        protected override PostalCode PredecessorImpl
        {
            get 
            { 
                var b = GenerateSuccesorOrPredecessor(GetInternalValue(), false);
                if (b == null) 
                {
                    return null;
                }
                return new MTPostalCode (b, _allowConvertToShort);
            }
        }

        protected override PostalCode SuccessorImpl
        {
            get 
            { 
                var b = GenerateSuccesorOrPredecessor(GetInternalValue(), true);
                if (b == null) 
                {
                    return null;
                }
                return new MTPostalCode (b, _allowConvertToShort);
            }
        }

        public override bool Equals (object obj)
        {
            var other = obj as MTPostalCode;
            if (other == null)
                return false;

            return PostalCodeString.Equals (other.PostalCodeString);
        }

        public override int GetHashCode ()
        {
            return PostalCodeString.GetHashCode ();
        }

        public override string ToHumanReadableString ()
        {
            var outputFormat = _currentFormat.OutputDefault;
            if (_currentFormatType == FormatType.Short) 
            {
                if (_currentFormat.OutputShort != null) 
                {
                    outputFormat = _currentFormat.OutputShort;
                }
            }

            return ToHumanReadableString(outputFormat);
        }
        
        public override PostalCode ExpandPostalCodeAsLowestInRange ()
        {
            if (_currentFormatType == FormatType.Short) {
                if (_currentFormat.ShortExpansionAsLowestInRange != null) {
                    return new MTPostalCode (ToString () + _currentFormat.ShortExpansionAsLowestInRange, false);
                } else {
                    throw new ArgumentException ("Requested short postal code expansion but no expansion provided (lowest)");
                }
            }

            return new MTPostalCode(ToString());
        }

        public override PostalCode ExpandPostalCodeAsHighestInRange ()
        {
            if (_currentFormatType == FormatType.Short) {
                if (_currentFormat.ShortExpansionAsHighestInRange != null) {
                    return new MTPostalCode (ToString () + _currentFormat.ShortExpansionAsHighestInRange, false);
                } else {
                    throw new ArgumentException ("Requested short postal code expansion but no expansion provided (highest)");
                }
            }

            return new MTPostalCode(ToString());
        }

        private static PostalCodeFormat[] _formats = new [] {
            new PostalCodeFormat {
                Name = "MA : A0A 0A0",
                RegexDefault = new Regex("^[A-Z]{3}[0-9]{4}$", RegexOptions.Compiled),
                OutputDefault = "xxx xxx",
            }
        };
    }
}
