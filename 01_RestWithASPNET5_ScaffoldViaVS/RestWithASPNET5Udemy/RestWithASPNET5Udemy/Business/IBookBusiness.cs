using RestWithASPNET5Udemy.Model;
using RestWithASPNETUdemy.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Business.Implementations
{
   public interface IBookBusiness
    {
        BookVO Create(BookVO book);

        BookVO FindByID(long id);

        List<BookVO> FindAll();

        BookVO Update(BookVO book);

        void Delete(long id);

    }
}
