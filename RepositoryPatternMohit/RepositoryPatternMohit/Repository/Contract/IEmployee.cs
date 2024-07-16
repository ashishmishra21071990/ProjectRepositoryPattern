using RepositoryPatternMohit.Models;

namespace RepositoryPatternMohit.Repository.Contract
{

    // Service
    public interface IEmployee
    {
        List<Employee> getEmployees();
        bool addEmployee(Employee empObj);
        Employee getEmployeeId(int id);
        bool updateEmployee(Employee empObj);
        bool deleteEmployee(int id);

    }
}
