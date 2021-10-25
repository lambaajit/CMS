using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dlwebclasses
{
    public class Bindings : Ninject.Modules.NinjectModule
    {

        public override void Load()
        {
            Bind<IMainNavigation>().To<MainNavigation>();

            
            
            //Bind<IDepartments>().To<deptMisleneous>().BindingConfiguration.IsImplicit = true;
            //Bind<IDepartments>().To<deptchildcare>().Named("Child Care");
            //Bind<IDepartments>().To<deptcivillitigation>().Named("Civil Litigation");
            //Bind<IDepartments>().To<deptcivillitigation>().Named("Litigation");
            //Bind<IDepartments>().To<deptCommunityCare>().Named("Community Care");
            //Bind<IDepartments>().To<deptConveyancing>().Named("Conveyancing");
            //Bind<IDepartments>().To<deptCrime>().Named("Crime");
            //Bind<IDepartments>().To<deptDebt>().Named("Debt & Insolvency");
            //Bind<IDepartments>().To<deptDebt>().Named("Debt");
            //Bind<IDepartments>().To<deptEmployment>().Named("Employment");
            //Bind<IDepartments>().To<deptFamily>().Named("Family");
            //Bind<IDepartments>().To<deptHousing>().Named("Housing");
            //Bind<IDepartments>().To<deptMentalHealth>().Named("Mental Health");
            //Bind<IDepartments>().To<deptMentalHealth>().Named("Mental Capacity");
            //Bind<IDepartments>().To<deptPublicLaw>().Named("Public Law");
            //Bind<IDepartments>().To<deptWelfareBenefits>().Named("Welfare Benefits");
            //Bind<IDepartments>().To<deptImmigration>().Named("Immigration");
            //Bind<IDepartments>().To<deptNews>().Named("Main");
            //Bind<IDepartments>().To<deptInThePress>().Named("InThePress");
            //Bind<IDepartments>().To<deptLegalNews>().Named("Legal News");
            //Bind<IDepartments>().To<deptClinicalNegligence>().Named("Clinical Negligence");
            //Bind<IDepartments>().To<deptProfessionalNegligence>().Named("Professional Negligence");
            //Bind<IDepartments>().To<deptIslamicLaw>().Named("Islamic Law");
            //Bind<IDepartments>().To<deptPersonalInjury>().Named("Personal Injury");
            //Bind<IDepartments>().To<deptReportedCase>().Named("Reported Case"); ;
            //Bind<IDepartments>().To<deptPrisonLaw>().Named("Prison Law");
            //Bind<IDepartments>().To<deptAboutUs>().Named("About Us");
            //Bind<IDepartments>().To<deptProfessionalRegulation>().Named("Professional Regulation");
            //Bind<IDepartments>().To<deptHumanRights>().Named("Human Rights");
            //Bind<IDepartments>().To<deptCareers>().Named("Careers");
            //Bind<IDepartments>().To<deptConsultancy>().Named("Consultancy");
            //Bind<IDepartments>().To<deptBusinessImmigration>().Named("Business Immigration");
            //Bind<IDepartments>().To<deptFeesFunding>().Named("Fees & Funding");
            //Bind<IDepartments>().To<deptMisleneous>().Named("Misleneous");
            //Bind<IDepartments>().To<deptActionAgainstPolice>().Named("Action Against Police");
            //Bind<IDepartments>().To<deptFindUs>().Named("FindUs");
            //Bind<IDepartments>().To<deptManagementBoard>().Named("Management Board");
            //Bind<IDepartments>().To<deptWillsandProbate>().Named("Wills and Probate");
            //Bind<IDepartments>().To<deptEU>().Named("EU");
            //Bind<IDepartments>().To<deptCampaign>().Named("Campaign");

        }
    }
}


