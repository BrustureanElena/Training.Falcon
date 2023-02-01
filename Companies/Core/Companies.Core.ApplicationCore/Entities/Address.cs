using EnsureThat;
using System;

namespace Companies.Core.ApplicationCore.Entities
{
    public class Address
    {
        /// <summary>
        /// Company Unique Identifier
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Street name
        /// </summary>
        public string Street { get; private set; }

        /// <summary>
        /// Street number
        /// </summary>
        public string Number { get; private set; }

        /// <summary>
        /// City name
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Address type
        /// </summary>
        public string AddressType { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="street">Required parameter</param>
        /// <param name="number">Required parameter</param>
        /// <param name="city">Required parameter</param>
        /// <param name="addressType">Required parameter</param>
        public Address(string street, string number, string city, string addressType)
        {
            Id = Guid.NewGuid();
            SetStreet(street);
            SetNumber(number);
            SetCity(city);
            SetAddressType(addressType);
        }

        /// <summary>
        /// Address Type setter
        /// </summary>
        /// <param name="addressType">Required parameter</param>
        /// <exception cref="ArgumentException">Throw if Address Type name is empty or null</exception>
        public void SetAddressType (string addressType)
        {
            EnsureArg.IsNotNullOrEmpty(addressType);

            switch (addressType)
            {
                case "Correspondence":
                    AddressType = addressType;
                    break;
                case "Commercial":
                    AddressType = addressType;
                    break;
                default:
                    throw new Exception("Please define the address type as Correspondence or Commercial.");
            }
        }

        /// <summary>
        /// Street name setter
        /// </summary>
        /// <param name="street">Required parameter</param>
        /// <exception cref="ArgumentException">Throw if Street name is empty or null.</exception>
        public void SetStreet(string street)
        {
            EnsureArg.IsNotNullOrEmpty(street);
            Street = street;
        }

        /// <summary>
        /// Street number setter
        /// </summary>
        /// <param name="number">Required parameter</param>
        /// <exception cref="ArgumentException">Throw if Number is empty or null.</exception>
        public void SetNumber(string number)
        {
            EnsureArg.IsNotNullOrEmpty(number);
            Number = number;
        }

        /// <summary>
        /// City name setter
        /// </summary>
        /// <param name="city">Required parameter</param>
        /// <exception cref="ArgumentException">Throw if City name is empty or null.</exception>
        public void SetCity(string city)
        {
            EnsureArg.IsNotNullOrEmpty(city);
            City = city;
        }
    }
}
