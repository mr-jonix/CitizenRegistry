using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizens
{
    public class Citizen : ICitizen
    {
        private DateTime dateOfBirth;
        private string firstName;
        private Gender gender;
        private string lastName;
        private string vatID;

        public Citizen(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
        {
            if ((int)gender > Enum.GetNames(typeof(Gender)).Length - 1)
            {
                throw new ArgumentOutOfRangeException("Gender parameter is out of allowed range");
            }
            if (DateTime.Compare(dateOfBirth, SystemDateTime.Now()) > 0)
            {
                throw new ArgumentException("Birth date cannot be set to a future date");
            }

            FirstName = firstName;
            LastName = lastName;
            BirthDate = dateOfBirth.Date;
            Gender = gender;
        }

        public DateTime BirthDate
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                    dateOfBirth = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = Recapitalizer.RecapitalizeName(value);
            }
        }

        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = Recapitalizer.RecapitalizeName(value);
            }
        }

        public string VatId
        {
            get
            {
                return vatID;
            }

            set
            {
                vatID = value;
            }
        }
    }
}
