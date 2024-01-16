using gRPCDataBase.Model;
using System.Data;
using System.Data.SqlClient;

namespace gRPCDataBase.Services
{
    public class EmployeeRepository
    {
        private string connectionString = "Data Source=;Initial Catalog=gRPC;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True;"; // Replace with your connection string

        public List<Employee> GetEmployees(int ID)
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Sp_EmployeeGet", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", ID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                Email = reader["Email"].ToString(),
                                Emp_Name = reader["Emp_Name"].ToString(),
                                Designation = reader["Designation"].ToString()
                            };
                            employees.Add(employee);
                        }
                    }
                }
            }
            return employees;
        }
     
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Sp_EmployeeAdd2", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", employee.ID);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@empName", employee.Emp_Name);
                    command.Parameters.AddWithValue("@Designation", employee.Designation);
                    command.Parameters.AddWithValue("@Created_date", "2023-10-29");
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void DeleteEmployee(int ID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("Sp_EmployeeDelete", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", ID);
                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
