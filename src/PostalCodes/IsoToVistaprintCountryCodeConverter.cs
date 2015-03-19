﻿using System;

namespace PostalCodes
{
    /// <summary>
    /// Class IsoToVistaprintCountryCodeConverter.
    /// </summary>
    public class IsoToVistaprintCountryCodeConverter
    {
        /// <summary>
        /// Gets the vistaprint country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public string GetVistaprintCountryCode(string countryCode)
        {
            if (!CountryCodes.ValidCountryCodes.Contains(countryCode))
            {
                throw new InvalidOperationException(string.Format("The specified country code is not valid: {0}", countryCode));
            }

            return IsoToVistaprint(countryCode);
        }

        /// <summary>
        /// Isoes to vistaprint.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>System.String.</returns>
        private string IsoToVistaprint(string countryCode)
        {
            switch (countryCode)
            {
                case "CW":
                case "SX":
                case "BQ":
                    return "AN";
                case "GB":
                    return "UK";
                default:
                    return countryCode;
            }
        }
    }
}