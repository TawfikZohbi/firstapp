using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Task3.Controllers;
using Task3.Models;


namespace Task3.Services
{
   public interface IStore
    {
        SubmissionResponse SaveEmployee(Employee employee);
      
       List<Employee> GetEmployee(string employeeName);

    }
}
