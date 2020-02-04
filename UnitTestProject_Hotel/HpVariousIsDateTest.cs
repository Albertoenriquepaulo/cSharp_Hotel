using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SetRooms;
using System.Runtime.CompilerServices;
using SetRooms.Class.Helpers;

namespace UnitTestProject_Hotel
{
    [TestClass]
    public class HpVariousIsDateTest
    {

        public const bool Expected = true;
        [TestMethod]
        public void EvaluateIfTheString_IsADate()
        {
            // ARRANGE - Preparación
            String date = "3/9/2008";
            Boolean result;

            // ACT - EJECUCION
            result = HpVarious.IsDate(date);


            // ASSERT - COMPROBACION
            Assert.IsTrue(result);
        }
    }
}
