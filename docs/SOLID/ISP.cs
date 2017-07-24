public IRepository<T>
{
    T GetById(int id);
    IEnumerable<T> List();
    void Create(T item);
    void Update(T item);
    void Delete(T item);    
}