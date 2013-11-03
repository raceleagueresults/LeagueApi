using System.Collections.Generic;
using Domain.MainModule.Entities;
using System.ServiceModel;

namespace DistributedServices.MainModule
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract(Name = "GetPersons")]
		List<PersonProfile> GetPersons();

        [OperationContract(Name = "GetPerson")]
		PersonProfile GetPerson(int personId);

        [OperationContract(Name = "AddPerson")]
		void AddPerson(PersonProfile person);

        [OperationContract(Name = "DeletePerson")]
        void DeletePerson(int personId);

        [OperationContract(Name = "UpdatePerson")]
        void UpdatePerson(PersonProfile person);

    }
}
