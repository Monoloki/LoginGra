using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestAdminExist()
        {

            using (var b = new LoginEntities())
            {
                var query = b.Main;
            }

        }
    }
}
