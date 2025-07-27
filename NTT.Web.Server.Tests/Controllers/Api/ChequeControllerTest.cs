using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Web.Http.Results;
using AKQA.Common;
using AKQA.Common.Abstraction;
using AKQA.Common.Formatter;
using AKQA.Web.Server.Controllers.Api;
using AKQA.Web.Server.Models;
using NUnit.Framework;


namespace AKQA.Web.Server.Tests.Controllers.Api
{
    [TestFixture]
    public class ChequeControllerTest
    {
        private ChequeController _controller;

        [SetUp]
        public void Init()
        {
            INumberToTextLanguageFormatter convertorLanguageFormater = new CustomEnglishWithDollarFormatter();
            INumberToTextConvertor numberConvertor = new NumberToTextConvertor(convertorLanguageFormater);
            _controller = new ChequeController(numberConvertor);
        }
        [Test]
        public void Print_WithNullAmount_Throws_Exception()
        {
            //Arrange
            var data = new Cheque() { fullname = "John Smith", amount = null };

            //Act
            TestDelegate act = () => _controller.Print(data);

            //Assert
            Assert.Throws<InvalidEnumArgumentException>(act);
        } 
        [Test]
        public void Print_WithInvalidAmount_Throws_Exception()
        {
            //Arrange          
            var data = new Cheque() { fullname= "John Smith", amount= "klk" };

            //Act
            TestDelegate act = () => _controller.Print(data);

            //Assert
            Assert.Throws<InvalidEnumArgumentException>(act);
        }
        [Test]
        public void Print_WithFullName_and_Amount_Return_OK()
        {
            //Arrange
            var data = new Cheque() { fullname = "John Smith", amount = "123.45" };            

            //Act
           var act = _controller.Print(data);

            //Assert
           Assert.IsTrue(act!=null);
        }
    }
}
