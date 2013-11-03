using System.ServiceModel;

namespace DistributedServices.Deployment
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPerson" in both code and config file together.
    [ServiceContract]
    public interface IPerson
    {
        [OperationContract]
        void DoWork();
    }
}
