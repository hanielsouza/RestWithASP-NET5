using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        

        T Create(T item);

        T FindByID(long id);

        List<T> FindAll();

        T Update(T item);

        void Delete(long id);

        bool Existis(long id);
    }
}
