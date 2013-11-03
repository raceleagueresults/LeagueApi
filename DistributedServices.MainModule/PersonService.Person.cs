using System.Collections.Generic;
using System.Globalization;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.IoC;

namespace DistributedServices.MainModule
{
    public partial class PersonService
    {
    	private readonly Domain.MainModule.Person.IPersonService _personService;

        public PersonService()
        {
			_personService = IoCFactory.Resolve<Domain.MainModule.Person.IPersonService>();
        }

        public List<PersonProfile> GetPersons()
        {
			return _personService.GetAllPersons();
        }

		public PersonProfile GetPerson(int personId)
        {
			return _personService.FindPersonByCode(personId.ToString(CultureInfo.InvariantCulture));
        }

		public void AddPerson(PersonProfile person)
        {
			_personService.AddPerson(person);
        }

        public void DeletePerson(int personId)
        {
			var person = _personService.FindPersonByCode(personId.ToString(CultureInfo.InvariantCulture));

			_personService.RemovePerson(person);
        }

        public void UpdatePerson(PersonProfile person)
        {
			_personService.ChangePerson(person);
        }

    }
}
