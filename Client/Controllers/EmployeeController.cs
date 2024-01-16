using gRPCDataBase.Services;
using GrpcService;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeService employeeService = new EmployeeService();
        [HttpGet("GetEmployeeById")]
        public EmployeeListResponse GetEmployeeById(int id)
        {
            EmployeeRequest employeeRequest = new EmployeeRequest();
            employeeRequest.ID = id;
            return employeeService.GetEmployee(employeeRequest, null).Result;
        }
        //add function to add employee
        
        [HttpPost("AddEmployee")]
        public void AddEmployee(EmployeeRequest employeeRequest)
        {
            employeeService.AddEmployee(employeeRequest, null);
        }
        //add function to delete employee
        [HttpDelete("DeleteEmployee")]
        public void DeleteEmployee(int id)
        {
            EmployeeRequest employeeRequest = new EmployeeRequest();
            employeeRequest.ID = id;
            employeeService.DeleteEmployee(employeeRequest, null);
        }
    }
   

}
