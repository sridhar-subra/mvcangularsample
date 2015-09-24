using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLibrary;
using Framework;
using Aveeno.WebAPI;
using Moq;
using System.Web.Http;
using AutoMapper;
using System.Web.Http.Results;


namespace WebAPITest
{
    [TestClass]
    public class PatientControllerTest
    {
        [TestMethod]
        public void GetRetrunsPatient()
        {
            //Arrange
            var mockPatientMgr = new Mock<IPatientManager>();
            var mockLog = new Mock<ILogger>();
            mockPatientMgr.Setup(x => x.GetPatient(1))
                .Returns(new BusinessLibrary.Patient { PatientId = 1 });
       
            var patientController = new PatientController(mockPatientMgr.Object, mockLog.Object);
            Mapper.CreateMap<BusinessLibrary.Patient, Aveeno.WebAPI.Patient>();
            //Act                        
            var result = patientController.Get(1);
            var contentResult = result as System.Web.Http.Results.OkNegotiatedContentResult<Aveeno.WebAPI.Patient>;

            //Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.PatientId);
        }

        [TestMethod]
         public void GetDoesNotRetrunPatient()
         {
             //Arrange
             var mockPatientMgr = new Mock<IPatientManager>();
             var mockLog = new Mock<ILogger>();
             mockPatientMgr.Setup(x => x.GetPatient(1))
                 .Returns(new BusinessLibrary.Patient { PatientId = 1 });

             var patientController = new PatientController(mockPatientMgr.Object, mockLog.Object);
             Mapper.CreateMap<BusinessLibrary.Patient, Aveeno.WebAPI.Patient>();

             //Act                        
             var result = patientController.Get(5);
           
             //Assert
             Assert.IsInstanceOfType(result, typeof(NotFoundResult));
         }
        
    }
}
