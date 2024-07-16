using RepositoryPatternMohit.Models;

namespace RepositoryPatternMohit.Repository.Contract
{

    // Service
    public interface IDepartment
    {
        List<Department> GetDepartments();
        bool addDepartment(Department empObj);
        Department getDepartmentById(int id);
        bool updateDepartment(Department empObj);
        bool deleteDepartment(int id);

    }
}
