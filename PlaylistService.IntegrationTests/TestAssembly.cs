using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.ServiceModel;
namespace PlaylistService.IntegrationTests
{
    [TestClass]
    public static class TestAssembly
    {
        public static ServiceHost ServiceHost_PlaylistService;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            var uri = new Uri("http://localhost:50462/");
            var basicBinding = new BasicHttpBinding();
            ServiceHost_PlaylistService = new ServiceHost(typeof(TeleVox.VXML.Services.VXMLService));
            ServiceHost_PlaylistService.AddServiceEndpoint(typeof(TeleVox.VXML.ServiceContracts.IAudioPlayList), basicBinding, $"{uri}VXMLService.svc");
            ServiceHost_PlaylistService.AddServiceEndpoint(typeof(TeleVox.VXML.ServiceContracts.ICallPacingService), basicBinding, $"{uri}VXMLService.svc");
            ServiceHost_PlaylistService.Open();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            ServiceHost_PlaylistService?.Close();
        }
    }
}
