using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Model.context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5Udemy.Repository.Implementations
{
    public class BookRepostoryImplementation : IBookRepository
    {
        private MySqlContext _context;

        public BookRepostoryImplementation(MySqlContext context)
        {
            _context = context;
        }


        public List<Book> FindAll()
        {
            return _context.books.ToList();
        }

        public Book FindByID(long id)
        {
            return _context.books.SingleOrDefault(x => x.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }



        public Book Update(Book book)
        {
            if (!Existis(book.Id)) return null;

            var result = _context.books.SingleOrDefault(p => p.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public bool Existis(long id)
        {
            return _context.books.Any(b => b.Id.Equals(id));
        }
    }
}
