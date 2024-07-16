using Microsoft.EntityFrameworkCore;
using RepositoryPatternMohit.Models;
using RepositoryPatternMohit.Repository.Contract;

namespace RepositoryPatternMohit.Repository.Services
{
    public class DepartmentService : IDepartment
    {
        private EmployeeDbContext _dbContext;
        public DepartmentService(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool addDepartment(Department dpObj)
        {
            _dbContext.Departments.Add(dpObj);
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

        public bool deleteDepartment(int id)
        {
            var department = _dbContext.Departments.Where(m => m.Did == id).FirstOrDefault();
            _dbContext.Remove(department);
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

        public Department getDepartmentById(int id)
        {
            var department = _dbContext.Departments.Where(m => m.Did == id).FirstOrDefault();
            return department;
        }

        public List<Department> GetDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public bool updateDepartment(Department dbObj)
        {
            _dbContext.Entry(dbObj).State = EntityState.Modified;
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
