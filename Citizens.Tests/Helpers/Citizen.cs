using System;

namespace Citizens.Tests.Helpers
{
    internal class Citizen: ICitizen
    {
        private DateTime dateOfBirth;
        private string firstName;
        private Gender gender;
        private string lastName;
        private string vatID;

        public string VatId
        {
            get { return vatID; }
            set { vatID = value; }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
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
                lastName = value;
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

        public Citizen(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
        {
            if ((int)gender > Enum.GetNames(typeof(Gender)).Length-1)
            {
                throw new ArgumentOutOfRangeException("Gender parameter is out of allowed range");
            }
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.gender = gender;
        }
    }
}