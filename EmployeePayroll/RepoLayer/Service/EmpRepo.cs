using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;

namespace RepoLayer.Service
{
    public class EmpRepo : IEmpRepo
    {
        private readonly IConfiguration _configuration;
        private readonly string ConnectionString;
        public EmpRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("EmployeeMVC_DB");
        }
        public string AddEmpData(Empmodel empmodel)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                using (sqlConnection)
                {

                    //Select * from tablename
                    SqlCommand cmd = new SqlCommand("SPAddingData", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Employee_Name", empmodel.Employee_Name);
                    cmd.Parameters.AddWithValue("@Profile_Image", empmodel.Profile_Image);
                    cmd.Parameters.AddWithValue("@Gender", empmodel.Gender);
                    cmd.Parameters.AddWithValue("@Department", empmodel.Department);
                    cmd.Parameters.AddWithValue("@Salary", empmodel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", empmodel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", empmodel.Notes);
                    sqlConnection.Open();
                    int val = cmd.ExecuteNonQuery();
                    string result = val.ToString();
                    sqlConnection.Close();
                    return result;

                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Empmodel UpdateEmp(Empmodel empmodel)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("SPUpdateData", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_Id", empmodel.Emp_Id);
                cmd.Parameters.AddWithValue("@Employee_Name", empmodel.Employee_Name);
                cmd.Parameters.AddWithValue("@Profile_Image", empmodel.Profile_Image);
                cmd.Parameters.AddWithValue("@Gender", empmodel.Gender);
                cmd.Parameters.AddWithValue("@Department", empmodel.Department);
                cmd.Parameters.AddWithValue("@Salary", empmodel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", empmodel.StartDate);
                cmd.Parameters.AddWithValue("@Notes", empmodel.Notes);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                if (empmodel != null)
                {
                    return empmodel;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public string DeleteEmployee(int employeeId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand("SPDelete", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Emp_Id", employeeId);
                connection.Open();
                int val = sqlCommand.ExecuteNonQuery();
                string result = val.ToString();
                connection.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Empmodel> GetAllEmployees()
        {
            try
            {
                List<Empmodel> employees = new List<Empmodel>();
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SPRetrieveAllData", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Empmodel model = new Empmodel();
                        model.Emp_Id = dataReader.GetInt32(0);
                        model.Employee_Name = dataReader.GetString(1);
                        model.Profile_Image = dataReader.GetString(2);
                        model.Gender = dataReader.GetString(3);
                        model.Department = dataReader.GetString(4);
                        model.Salary = dataReader.GetInt64(5);
                        model.StartDate = dataReader.GetDateTime(6);
                        model.Notes = dataReader.GetString(7);
                        employees.Add(model);
                    }
                }
                connection.Close();
                return employees;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Empmodel GetEmployeeById(int emp_Id)
        {
            try
            {
                string query = "SELECT * FROM EMPLOYEE WHERE Emp_Id= " + emp_Id;
                Empmodel employee = new Empmodel();
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    employee.Emp_Id = Convert.ToInt32(reader["Emp_Id"]);
                    employee.Employee_Name = reader["Employee_Name"].ToString();
                    employee.Profile_Image = reader["Profile_Image"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.Department = reader["Department"].ToString();
                    employee.Salary = Convert.ToInt64(reader["Salary"]);
                    employee.StartDate = reader.GetDateTime(6);
                    employee.Notes = reader["Notes"].ToString();
                }
                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Empmodel LoginEmployee(EmpLoginModel loginModel)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand("SPLogin", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Emp_Id", loginModel.EmployeeId);
                sqlCommand.Parameters.AddWithValue("@Employee_Name", loginModel.Employee_Name);
                connection.Open();
                //var val=sqlCommand.Parameters.Add("@Result",SqlDbType.Int);
                //val.Direction = ParameterDirection.ReturnValue;
                Empmodel empmodel = new Empmodel();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    empmodel.Emp_Id = reader.GetInt32(0);
                    empmodel.Employee_Name = reader.GetString(1);
                }

                return empmodel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public string AddReview(ReviewModel reviewModel)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                using(sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("SPAdd", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", reviewModel.Name);
                    cmd.Parameters.AddWithValue("@Comment", reviewModel.Comment);
                    sqlConnection.Open();
                    int val = cmd.ExecuteNonQuery();
                    string result = val.ToString();
                    return result;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

    }
}
