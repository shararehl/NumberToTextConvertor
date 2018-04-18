using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using AKQA.Common.Abstraction;
using AKQA.Common.Entities;
using AKQA.Web.Server.Models;
using Newtonsoft.Json.Linq;

namespace AKQA.Web.Server.Controllers.Api
{

    public partial class ChequeController : ApiController
    {
        private readonly INumberToTextConvertor _numberToTextConvertor;

        public ChequeController(INumberToTextConvertor numberToTextConvertor)
        {
            _numberToTextConvertor = numberToTextConvertor;
        }

        [HttpPost]
        public IHttpActionResult Print([FromBody]Cheque data)
        {
            if (ModelState.IsValid)
            {
                var jsonResult = new ExpandoObject() as IDictionary<string, object>;
                var TextAmount = _numberToTextConvertor.Convert(data.amount);
                jsonResult.Add("fullname", data.fullname);
                jsonResult.Add("amount", TextAmount.ToUpper());
                return Ok(jsonResult);
            }
            return BadRequest();
        }
    }
}
