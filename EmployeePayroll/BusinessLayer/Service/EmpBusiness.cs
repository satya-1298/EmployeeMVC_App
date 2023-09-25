using BusinessLayer.Interface;
using CommonLayer.Model;
using RepoLayer.Interface;
using RepoLayer.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmpBusiness:IEmpBusiness
    {
        private readonly IEmpRepo _empRepo;
        public EmpBusiness(IEmpRepo emp) 
        {
            this._empRepo = emp;
        }
        public string AddEmpData(Empmodel empmodel)
        {
            try
            {
                return _empRepo.AddEmpData(empmodel);
            }
            catch
            {
                throw;
            }

        }
        public Empmodel UpdateEmp(Empmodel empmodel) 
        {

            try
            {
                return _empRepo.UpdateEmp(empmodel);
            }
            catch
            {
                throw;
            }
        }
        public string DeleteEmployee(int empId)
        {
            try
            {
                return _empRepo.DeleteEmployee(empId);
            }
            catch
            {
                throw;
            }
        }
        public IEnumerable<Empmodel> GetAllEmployees()
        {
            try
            {
                return _empRepo.GetAllEmployees();
            }
            catch
            {
                throw;
            }
        }
        public Empmodel GetEmployeeById(int emp_Id)
        {
            try
            {
                return _empRepo.GetEmployeeById(emp_Id);
            }
            catch
            {
                throw;
            }
        }
        public Empmodel LoginEmployee(EmpLoginModel loginModel)
        {
            try
            {
                return _empRepo.LoginEmployee(loginModel);
            }
            catch
            {
                throw;
            }
        }
        public string AddReview(ReviewModel reviewModel)
        {
            try
            {
                return _empRepo.AddReview(reviewModel);
            }
            catch
            {
                throw;
            }
        }
    }
}
