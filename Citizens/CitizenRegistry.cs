using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Citizens
{
    public class CitizenRegistry : ICitizenRegistry
    {
        public List<ICitizen> CitizensList = new List<ICitizen>();
        private VatNumberAssigner VNA = new VatNumberAssigner();
        private int MaleCount = 0;
        private int FemaleCount = 0;
        private DateTime LastRegistration;

        public ICitizen this[string id]
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException();
                }
                if (CitizensList.Find(x => x.VatId == id) != null)
                {
                    return CitizensList.Find(x => x.VatId == id);
                }
                else
                {
                    return null;
                }
            }
        }

        public void Register(ICitizen citizen)
        {
            if (String.IsNullOrEmpty(citizen.VatId) || citizen.VatId.Length < 10)
            {
                citizen.VatId = VNA.AssignNumber(citizen.BirthDate, citizen.Gender);
            }

            if (CitizensList.Exists(x => x.VatId == citizen.VatId))
            {
                throw new InvalidOperationException("A Citizen with this VAT ID already exists");

            }
            else
            {
                ICitizen citizenCopy = new Citizen
                {
                    FirstName = citizen.FirstName,
                    LastName = citizen.LastName,
                    BirthDate = citizen.BirthDate,
                    Gender = citizen.Gender,
                    VatId = citizen.VatId
                };
                CitizensList.Add(citizenCopy);
                LastRegistration = SystemDateTime.Now();
                if (citizenCopy.Gender == Gender.Male) MaleCount++; else FemaleCount++;
            }
        }

        public string Stats()
        {
            var message = new StringBuilder();
            message.Append(MaleCount + " ");
            if (MaleCount % 10 == 1) message.Append("man ");
            else message.Append("men ");

            message.Append("and "+ FemaleCount + " ");
            if (FemaleCount % 10 == 1) message.Append("woman");
            else message.Append("women");

            if ((MaleCount+FemaleCount)>0)
            {
                var dateMsg = string.Empty;
                switch ((SystemDateTime.Now().Date - LastRegistration.Date).Days)
                {
                    case 0: dateMsg = "today";
                        break;
                    case 1: dateMsg = "yesterday";
                        break;
                    default: dateMsg = (SystemDateTime.Now().Date - LastRegistration.Date).Days + " days ago";
                        break;
                }
                message.Append(". Last registration was "+dateMsg);
            }

            return message.ToString();


        }
    }

}
