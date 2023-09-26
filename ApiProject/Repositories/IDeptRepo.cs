using ApiProject.Models;

namespace ApiProject.Repositories
{
    public interface IDeptRepo
    {
        public IEnumerable<Department> GetAll();
        public Department GetById(int id);
        public Department GetByName(string Name);
    
        public Department Add(Department department);
        public Department Delete(int id);

    }
}
