using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using dlwebclasses;

namespace nunittests
{
    [TestFixture]
    public class alltests
    {
        [Test]
        public void testwebpagecontents()
        {
            WebPages WP = new WebPages();
            StringBuilder SB = WP.getwebpagecontents(127);
            StringAssert.Contains("Serious Injury Solicitors", SB.ToString());
        }
    }
}
