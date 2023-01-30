using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.Models;

namespace ClientConvertisseurV2.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            Thread.Sleep(1000);
            WSService service = new WSService("");
            var result = service.GetDevisesAsync("devises").Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, new List<Devise>().GetType());
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod()]        
        public void WSServiceTest()
        {
            WSService service = new WSService("");
            Assert.IsNotNull(service);
        }
    }
}