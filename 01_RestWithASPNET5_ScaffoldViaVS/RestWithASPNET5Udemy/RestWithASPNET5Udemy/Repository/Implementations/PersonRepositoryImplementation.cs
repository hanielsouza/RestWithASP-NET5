using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Model.context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5Udemy.Repository
{
    public class PersonRepositoryImplementation : IPersonRepository
    {

        private MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }



        public List<Person> FindAll()
        {


            return _context.people.ToList();
        }



        public Person FindByID(long id)
        {


            return _context.people.SingleOrDefault(p => p.Id.Equals(id));

        }


        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Existis(person.Id)) return null;

            var result = _context.people.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return person;

        }

        public void Delete(long id)
        {
            var result = _context.people.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.people.Remove(result);
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
            return _context.people.Any(p => p.Id.Equals(id));
        }
    }
}
