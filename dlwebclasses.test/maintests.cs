using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace dlwebclasses.test
{
    [TestClass]
    public class maintests
    {
        [TestMethod]
        public void TestMethod1()
        {
            staffbasicdetails sbd = new staffbasicdetails("YeungG");
            Assert.IsInstanceOfType(sbd._IStaffProfile, typeof(staffprofileitdatabase));
        }

        [TestMethod]
        public void checkwebpagecontent()
        {
            WebPages WP = new WebPages();
            StringBuilder SB = WP.getwebpagecontents(127);
            Assert.IsNotNull(SB);
            
        }
    }
}
