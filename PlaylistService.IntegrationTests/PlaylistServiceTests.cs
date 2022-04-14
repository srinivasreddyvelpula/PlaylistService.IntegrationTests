using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.IO;

namespace PlaylistService.IntegrationTests
{
    [TestClass]
    public class PlaylistServiceTests
    {
        [TestMethod]
        public void SubmitOutboundCallRequest()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"TestFiles\OutboundCallRequest_001.xml");
            string xml = File.ReadAllText(filePath);
            var request = (VXMLServiceReference.OutboundCallRequest)xml.DeserializeContractObject(typeof(VXMLServiceReference.OutboundCallRequest));
            request.CallID = Guid.NewGuid();
            request.PhoneNumber = "2517253233"; // change or update to shared number

            var client = new VXMLServiceReference.VXMLServiceClient();
            var response = client.SubmitOutboundCallRequest(request);

            Assert.AreEqual(VXMLServiceReference.ResponseCode.Success, response.ResponseCode);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetWICPortStatus()
        {
            var client = new VXMLServiceReference.VXMLServiceClient();
            client.GetWICPortStatus();
        }
    }
}
