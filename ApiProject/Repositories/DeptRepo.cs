using ApiProject.Models;

namespace ApiProject.Repositories
{
    public class DeptRepo : IDeptRepo
    {
        private readonly ITIContext _context;
        public DeptRepo(ITIContext context)
        {
            _context = context;
        }

        public Department Add(Department department)
        {
            _context.Add(department);
            return department;
        }

        public Department Delete(int id)
        {
            var deleteRes = GetById(id);
                _context.Remove(deleteRes);
            _context.SaveChanges();
                return deleteRes;
        }

        public IEnumerable<Department> GetAll()
        {
            var Depts = _context.Departments.ToList();
            return Depts;
        }

        public Department GetById(int id)
        {
            var Dept = _context.Departments.FirstOrDefault(f=>f.Id == id);
            return Dept;

        }

        public Department GetByName(string Name)
        {
            var DeptbyName = _context.Departments.FirstOrDefault(f=>f.Name == Name);
            return DeptbyName;
        }

        

    
    }
}
