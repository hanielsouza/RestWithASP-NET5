using RestWithASPNET5Udemy.Data.Converter.Implementation;
using RestWithASPNET5Udemy.Data.VO;
using RestWithASPNET5Udemy.Hypermedia.Utils;
using RestWithASPNET5Udemy.Model;
using RestWithASPNET5Udemy.Repository;
using System.Collections.Generic;

namespace RestWithASPNET5Udemy.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        private readonly IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }



        public List<PersonVO> FindAll()
        {


            return _converter.Parse(_repository.FindAll());
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {

            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from person p where 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) query += $" and p.first_name like '%{name}%'";
            query += $" order by p.first_name {sort} limit {size} offset {offset}";

            string countQuery = @"select count(*) from person p where 1 = 1";
            if (!string.IsNullOrWhiteSpace(name)) countQuery += $" and p.first_name like '%{name}%'";


            var persons = _repository.FindWithPagedSearch(query);
            int totalresults = _repository.GetCount(countQuery);

            return new PagedSearchVO<PersonVO>
            {
                CurrentPage = page,
                List = _converter.Parse(persons),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalresults
            };
        }


        //pega o obj entidade do banco e converte para VO

        public PersonVO FindByID(long id)
        {


            return _converter.Parse(_repository.FindByID(id));

        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.Parse(_repository.FindByName(firstName, lastName));
        }


        public PersonVO Create(PersonVO Person)
        {
            var personEntity = _converter.Parse(Person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public PersonVO Update(PersonVO Person)
        {
            var personEntity = _converter.Parse(Person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);

        }


        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }


    }
}
