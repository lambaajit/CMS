using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class staffprofileoldhrd:IStaffProfile
    {
        HRDDLEntities hr = new HRDDLEntities();
        public StringBuilder getstaffProfile(string staffcode)
        {
            Emp_Profile ep = new Emp_Profile();
            ep = hr.Emp_Profile.Where(x => x.emp_code == staffcode).FirstOrDefault();
            StringBuilder Pro = new StringBuilder();
            if (ep == null)
                Pro.Append("");
            else
                Pro.Append(ep.experience);

            Pro = allStatic.replacelinespacewithbr(Pro);
            return Pro;
        }
    }
}
