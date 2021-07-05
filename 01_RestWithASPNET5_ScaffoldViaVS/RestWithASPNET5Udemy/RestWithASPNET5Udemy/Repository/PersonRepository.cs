using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Model.context;
using RestWithASPNET5Udemy.Repository.Generic;
using System;
using System.Linq;

namespace RestWithASPNET5Udemy.Repository
{
    public class PersonRepository: GenericRepository<Person>,IPersonRepository
    {
        public PersonRepository(MySqlContext context): base(context)
        {

        }

        public Person Disable(long id)
        {
            if (!_context.people.Any(p => p.Id.Equals(id))) return null;
            var user = _context.people.SingleOrDefault(p => p.Id.Equals(id));
            if(user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return user;
        }
    }
}
