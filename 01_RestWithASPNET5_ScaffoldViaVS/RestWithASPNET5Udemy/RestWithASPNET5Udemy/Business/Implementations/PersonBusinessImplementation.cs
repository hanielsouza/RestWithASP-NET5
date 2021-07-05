using RestWithASPNET5Udemy.Data.Converter.Implementation;
using RestWithASPNET5Udemy.Data.VO;
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


        //pega o obj entidade do banco e converte para VO

        public PersonVO FindByID(long id)
        {


            return _converter.Parse(_repository.FindByID(id));

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
