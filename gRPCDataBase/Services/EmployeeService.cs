using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRPCDataBase.Model;
using GrpcService;

namespace gRPCDataBase.Services
{
    public class EmployeeService : EmployeeDetails.EmployeeDetailsBase
    {
        EmployeeRepository employeeRepo = new EmployeeRepository();

        public override Task<EmployeeListResponse> GetEmployee(EmployeeRequest request, ServerCallContext context)
        {

            var employess = employeeRepo.GetEmployees(request.ID);

            var employeeReponses = new List<EmployeeResponse>();
            foreach (var employee in employess)
            {
                employeeReponses.Add(new EmployeeResponse
                {
                    Email = employee.Email,
                    EmpName = employee.Emp_Name,
                    Designation = employee.Designation
                });
            }
            var employeeListresponse = new EmployeeListResponse
            {
                Employees = { employeeReponses }
            };
            return Task.FromResult(employeeListresponse);
        }
        public void AddEmployee(EmployeeRequest request, ServerCallContext context)
        {
            var employee = new Employee
            {
                ID = request.ID,
                Email = request.Email,
                Emp_Name = request.EmpName,
                Designation = request.Designation
            };
            employeeRepo.AddEmployee(employee);
        }
        public void DeleteEmployee(EmployeeRequest request, ServerCallContext context)
        {
            employeeRepo.DeleteEmployee(request.ID);
        }
    }
}
