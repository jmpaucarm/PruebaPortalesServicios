using Core.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace MSUnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        int value = 1;

        [TestMethod]
        public void TestMethod1()
        {
            ThreadPool.QueueUserWorkItem(CreateSession);

        }

        void CreateSession(Object stateInfo)
        {
            UserSession usrS = new UserSession();
            usrS.ProfileID = usrS.UserID =usrS.OfficeID = usrS.InstitutionID = value;
            
            value++;
        }
    }
}
