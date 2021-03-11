using RestWithASPNET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Business.Implementations
{
   public interface IBookBusiness
    {
        Book Create(Book book);

        Book FindByID(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);

    }
}
