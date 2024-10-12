namespace atelier1.Models.Repositories
{
    public interface IRepository<T>

    {
        double SalaryAverage();
        double MaxSalary();
        int HrEmployeesCount();
        List<T> Search(string term);
        
        IList<T> GetAll();
        T FindByID(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        

    }
}
