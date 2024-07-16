using Microsoft.EntityFrameworkCore;
using RepositoryPatternMohit.Models;
using RepositoryPatternMohit.Repository.Contract;

namespace RepositoryPatternMohit.Repository.Services
{
    public class EmployeeService : IEmployee
    {
        private EmployeeDbContext _dbContext;
        public EmployeeService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Employee> getEmployees()
        {
            return _dbContext.Employees.ToList();
        }
        public bool addEmployee(Employee empObj)
        {
            _dbContext.Employees.Add(empObj);
            int n=_dbContext.SaveChanges();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Employee getEmployeeId(int id)
        {
           var employee= _dbContext.Employees.Where(m => m.Eid == id).FirstOrDefault();
           return employee;
        }
        public bool updateEmployee(Employee empObj)
        {
            _dbContext.Entry(empObj).State = EntityState.Modified;
            int n=_dbContext.SaveChanges();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteEmployee(int id)
        {
            var employee = _dbContext.Employees.Where(m => m.Eid == id).FirstOrDefault();
            _dbContext.Remove(employee);
            int n = _dbContext.SaveChanges();
            if (n != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
