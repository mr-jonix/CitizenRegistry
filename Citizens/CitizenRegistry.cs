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

        public ICitizen this[string id]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Register(ICitizen citizen)
        {
            if (CitizensList.Exists(x => x.VatId == citizen.VatId))
            {
                throw new InvalidOperationException("A Citizen with this VAT ID already exists");

            }
            else
            {
                CitizensList.Add(citizen);
            }
        }

        public string Stats()
        {
            throw new NotImplementedException();
        }
    }

}
