namespace ToDoList.Generics.Interfaces
{
    public interface ICrud<T>
    {
        T Create(T item);
        T GetById(int id);
        bool Update(T item);
        bool Delete(int id);
        List<T> GetAll();
    }
}
