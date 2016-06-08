using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizens
{
    class VatNumberAssigner
    {
        public Dictionary<string,int> VATNumberEnums = new Dictionary<string, int>();
        DateTime startDate = new DateTime(1899, 12, 31);

        public string AssignNumber(DateTime dateOfBirth, Gender gender)
        {
            string dateKey = ((int)dateOfBirth.Date.Subtract(startDate).TotalDays).ToString("D5");
            if (VATNumberEnums.Keys.Contains(dateKey))
            {
                VATNumberEnums[dateKey]++;
            }
            else
            {
                VATNumberEnums.Add(dateKey, 0);
            }

            if ((gender == Gender.Male && VATNumberEnums[dateKey] % 2 == 0) || (gender == Gender.Female && VATNumberEnums[dateKey] % 2 != 0))
            {
                VATNumberEnums[dateKey]++;
            }

            string uniqueID = VATNumberEnums[dateKey].ToString("D4");
            int controlSum = (int)Char.GetNumericValue(dateKey[0])*-1;
            controlSum += (int)Char.GetNumericValue(dateKey[1]) * 5;
            controlSum += (int)Char.GetNumericValue(dateKey[2]) * 7;
            controlSum += (int)Char.GetNumericValue(dateKey[3]) * 9;
            controlSum += (int)Char.GetNumericValue(dateKey[4]) * 4;
            controlSum += (int)Char.GetNumericValue(uniqueID[0]) * 6;
            controlSum += (int)Char.GetNumericValue(uniqueID[1]) * 10;
            controlSum += (int)Char.GetNumericValue(uniqueID[2]) * 5;
            controlSum += (int)Char.GetNumericValue(uniqueID[3]) * 7;

            int controlDigit = (controlSum % 11) % 10;

            return dateKey + uniqueID + controlDigit;

        }
    }
}
