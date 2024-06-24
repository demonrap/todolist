namespace ToDoList.Interface
{
    public interface ICrud<TEntity, TKey>
    {
        TEntity Create(TEntity item);
        TEntity GetById(int id);
        bool Update(TEntity item);
        bool Delete(int id);
        List<TEntity> GetAll();
        void Print(string v);
    }
}
