using System;
namespace Infrastructure.Data.MainModule.Repositories
{
    public interface IClientRepository
    {
        Infrastructure.Data.MainModule.Models.Client Add(Infrastructure.Data.MainModule.Models.Client item);
        Infrastructure.Data.MainModule.Models.Client Delete(Guid token);
        Infrastructure.Data.MainModule.Models.Client Get(Guid token);
        System.Collections.Generic.IEnumerable<Infrastructure.Data.MainModule.Models.Client> List();
        Infrastructure.Data.MainModule.Models.Client Update(Infrastructure.Data.MainModule.Models.Client item);
    }
}
