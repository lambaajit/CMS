using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dlwebclasses
{
    public class staffprofileitdatabase:IStaffProfile
    {
        IT_DatabaseEntities db2 = new IT_DatabaseEntities();
        public StringBuilder getstaffProfile(string staffcode)
        {
            User_Profile_FinalDraft UP = new User_Profile_FinalDraft();
            UP = db2.User_Profile_FinalDraft.Where(x => x.Emp_code == staffcode).FirstOrDefault();
            StringBuilder Pro = new StringBuilder();
            Pro.AppendLine(UP.Profile);

            if (UP.Education_Status == "Yes")
            {
            Pro.AppendLine("<p>&nbsp;</p>");
            Pro.AppendLine("<h5>Education</h5>");
            Pro.AppendLine(UP.Education);
            }

            if (UP.Career_Status == "Yes")
            {
                Pro.AppendLine("<p>&nbsp;</p>");
                Pro.AppendLine("<h5>Career</h5>");
                Pro.AppendLine(UP.Career);
            }

if (UP.Supreme_Court_Status == "Yes" || UP.Court_of_Appeal_Status == "Yes" || UP.High_Court_Status == "Yes" || UP.Criminal_Court_Status == "Yes" || UP.Civil_Court_Status == "Yes")
{
            Pro.AppendLine("<p>&nbsp;</p>");
            Pro.AppendLine("<h5>Recent Notable Cases</h5>");

            if (UP.Supreme_Court_Status == "Yes")
            {
                Pro.AppendLine("<p>&nbsp;</p>");
                Pro.AppendLine("<h6>Supreme Court</h6>");
                Pro.AppendLine(UP.Supreme_Court);
            }

            if (UP.Court_of_Appeal_Status == "Yes")
            {
                Pro.AppendLine("<p>&nbsp;</p>");
                Pro.AppendLine("<h6>Court of Appeal</h6>");
                Pro.AppendLine(UP.Court_of_Appeal);
            }

            if (UP.High_Court_Status == "Yes")
            {
                Pro.AppendLine("<p>&nbsp;</p>");
                Pro.AppendLine("<h6>High Court</h6>");
                Pro.AppendLine(UP.High_Court);
            }

            if (UP.Criminal_Court_Status == "Yes")
            {
                Pro.AppendLine("<p>&nbsp;</p>");
                Pro.AppendLine("<h6>Criminal Court</h6>");
                Pro.AppendLine(UP.Criminal_Court);
            }

            if (UP.Civil_Court_Status == "Yes")
            {
                Pro.AppendLine("<p>&nbsp;</p>");
                Pro.AppendLine("<h6>Civil Courts & Tribunal</h6>");
                Pro.AppendLine(UP.Civil_Court);
            }
}


if (UP.Other_Supreme_Court_Status == "Yes" || UP.Other_Court_of_Appeal_Status == "Yes" || UP.Other_High_Court_Status == "Yes" || UP.Other_Criminal_Court_Status == "Yes" || UP.Other_Civil_Court_Status == "Yes")
{
    Pro.AppendLine("<h5>Other Notable Cases</h5>");
    if (UP.Other_Supreme_Court_Status == "Yes")
    {
        Pro.AppendLine("<p>&nbsp;</p>");
        Pro.AppendLine("<h6>Supreme Court</h6>");
        Pro.AppendLine(UP.Other_Supreme_Court);
    }

    if (UP.Other_Court_of_Appeal_Status == "Yes")
    {
        Pro.AppendLine("<p>&nbsp;</p>");
        Pro.AppendLine("<h6>Court of Appeal</h6>");
        Pro.AppendLine(UP.Other_Court_of_Appeal);
    }

    if (UP.Other_High_Court_Status == "Yes")
    {
        Pro.AppendLine("<p>&nbsp;</p>");
        Pro.AppendLine("<h6>High Court</h6>");
        Pro.AppendLine(UP.Other_High_Court);
    }

    if (UP.Other_Criminal_Court_Status == "Yes")
    {
        Pro.AppendLine("<p>&nbsp;</p>");
        Pro.AppendLine("<h6>Criminal Court</h6>");
        Pro.AppendLine(UP.Other_Criminal_Court);
    }

    if (UP.Other_Civil_Court_Status == "Yes")
    {
        Pro.AppendLine("<p>&nbsp;</p>");
        Pro.AppendLine("<h6>Civil Courts & Tribunal</h6>");
        Pro.AppendLine(UP.Other_Civil_Court);
    }
}

if (UP.Client_Comments_Status == "Yes")
{
    Pro.AppendLine("<p>&nbsp;</p>");
    Pro.AppendLine("<h5>Testimonies & Client Comments</h5>");
    Pro.AppendLine(UP.Client_Comments);
}

if (UP.Dir_RecAndAwards_Status == "Yes")
{
    Pro.AppendLine("<p>&nbsp;</p>");
    Pro.AppendLine("<h5>Recommendations & Awards</h5>");
    Pro.AppendLine(UP.Dir_RecAndAwards);
}

if (UP.MembershipAndAccreditations_Status == "Yes")
{
    Pro.AppendLine("<p>&nbsp;</p>");
    Pro.AppendLine("<h5>Membership & Accreditations</h5>");
    Pro.AppendLine(UP.MembershipAndAccreditations);
}
if (UP.Personal_Interests_Status == "Yes")
{
    Pro.AppendLine("<p>&nbsp;</p>");
    Pro.AppendLine("<h5>Interests</h5>");
    Pro.AppendLine(UP.Personal_Interests);
}

            Pro = allStatic.replacelinespacewithbr(Pro);
            return Pro;
        }
    }
}
