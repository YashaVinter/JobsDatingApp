﻿namespace JobsDatingApp.Models.Storage
{
    public interface IStorage<T>
    {
        T? Get(int Id);
        T? Post(T t);
        T? Put(T t);
        T? Delete(int Id);
    }
}
