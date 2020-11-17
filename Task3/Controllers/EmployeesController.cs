using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3.Models;
using Task3.Services;

namespace Task3.Controllers
{


    public class EmployeesController : Controller
    {
        private readonly IStore store;

        public EmployeesController(IStore store)
        {
            this.store = store;
        }
        [Route("api/[controller]")]
        [HttpPost()]
        public ActionResult<SubmissionResponse> SaveEmployee([FromBody] Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.Name))
            {
                return BadRequest(new SubmissionResponse
                {
                    Success = false,
                    ErrorCode = "InvalidModel"
                });

            }

            employee.Id = Guid.NewGuid();

            var submissionResult = store.SaveEmployee(employee);

            if (!submissionResult.Success)
            {
                return BadRequest(submissionResult);
            }

            return Ok(submissionResult);
        }
        [Route("api/[controller]/{name}")]
        [HttpGet()]
        public ActionResult<string> Get(string name)
        {
            var submissionResult = store.GetEmployee(name);
            return Ok(submissionResult);

        }
    }
}
