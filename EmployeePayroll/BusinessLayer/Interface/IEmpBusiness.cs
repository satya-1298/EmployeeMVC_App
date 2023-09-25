using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmpBusiness
    {
        public string AddEmpData(Empmodel empmodel);
        public Empmodel UpdateEmp(Empmodel empmodel);
        public string DeleteEmployee(int empId);
        public IEnumerable<Empmodel> GetAllEmployees();
        public Empmodel GetEmployeeById(int emp_Id);
        public Empmodel LoginEmployee(EmpLoginModel loginModel);
        public string AddReview(ReviewModel reviewModel);

    }
}
