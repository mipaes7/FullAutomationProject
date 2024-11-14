using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Builders
{
        public class UserDetails
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string DayOfBirth { get; set; }
            public string MonthOfBirth { get; set; }
            public string YearOfBirth { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Company { get; set; }
            public string Address { get; set; }
            public string Address2 { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string ZipCode { get; set; }
            public string Phone { get; set; }
        }

        public class UserDetailsBuilder
        {
            private UserDetails userDetails;

            public UserDetailsBuilder()
            {
                userDetails = new UserDetails();
            }

            public UserDetailsBuilder WithName(string name)
            {
                userDetails.Name = name;
                return this;
            }

            public UserDetailsBuilder WithEmail(string email) { userDetails.Email = email; return this; }

            public UserDetailsBuilder WithPassword(string password)
            {
                userDetails.Password = password;
                return this;
            }

            public UserDetailsBuilder WithDayOfBirth(string dayOfBirth)
            {
                userDetails.DayOfBirth = dayOfBirth;
                return this;
            }

            public UserDetailsBuilder WithMonthOfBirth(string monthOfBirth)
            {
                userDetails.MonthOfBirth = monthOfBirth;
                return this;
            }

            public UserDetailsBuilder WithYearOfBirth(string yearOfBirth)
            {
                userDetails.YearOfBirth = yearOfBirth;
                return this;
            }

            public UserDetailsBuilder WithFirstName(string firstName)
            {
                userDetails.FirstName = firstName;
                return this;
            }

            public UserDetailsBuilder WithLastName(string lastName)
            {
                userDetails.LastName = lastName;
                return this;
            }

            public UserDetailsBuilder WithCompany(string company)
            {
                userDetails.Company = company;
                return this;
            }

            public UserDetailsBuilder WithAddress(string address)
            {
                userDetails.Address = address;
                return this;
            }

            public UserDetailsBuilder WithAddress2(string address2)
            {
                userDetails.Address2 = address2;
                return this;
            }

            public UserDetailsBuilder WithCountry(string country)
            {
                userDetails.Country = country;
                return this;
            }

            public UserDetailsBuilder WithState(string state)
            {
                userDetails.State = state;
                return this;
            }

            public UserDetailsBuilder WithCity(string city)
            {
                userDetails.City = city;
                return this;
            }

            public UserDetailsBuilder WithZipCode(string zipCode)
            {
                userDetails.ZipCode = zipCode;
                return this;
            }

            public UserDetailsBuilder WithPhone(string phone)
            {
                userDetails.Phone = phone;
                return this;
            }

            public UserDetails Build()
            {
                return userDetails;
            }
        }

    }

