namespace lab7;
interface IProduct<T>
{
    void GetInfoAbout(T el);
    void Remove(T el);
    void Add(T el);
}
