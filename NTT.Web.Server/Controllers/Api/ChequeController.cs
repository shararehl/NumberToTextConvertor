using System.Collections.Generic;
using System.Dynamic;
using System.Web.Http;
using NTT.Common.Abstraction;
using NTT.Common.Entities;
using NTT.Web.Server.Models;
using Newtonsoft.Json.Linq;

namespace NTT.Web.Server.Controllers.Api
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
            try
            {
                if (ModelState.IsValid)
                {
                    var jsonResult = new ExpandoObject() as IDictionary<string, object>;
                    var TextAmount = _numberToTextConvertor.Convert(data.amount);
                    jsonResult.Add("fullname", data.fullname);
                    jsonResult.Add("amount", TextAmount.ToUpper());
                    return Ok(jsonResult);
                }
                return BadRequest("Error");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
