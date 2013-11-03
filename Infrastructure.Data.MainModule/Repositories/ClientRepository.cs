using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.Data.MainModule.Models;
using Domain.Core;
using System.Data.Entity;

namespace Infrastructure.Data.MainModule.Repositories
{
    public class ClientRepository : Infrastructure.Data.MainModule.Repositories.IClientRepository
    {
        private readonly ClientApiContext _context;

        public ClientRepository()
        {
            _context = new ClientApiContext();
        }

        public Client Add(Client item)
        {
            var addedItem = _context.Clients.Add(new Client()
            {
                Name = item.Name,
                Description = item.Description,
                DateCreated = DateTime.Now
            });

            _context.SaveChanges();

            return addedItem;
        }

        public Client Update(Client item)
        {
            var itemToUpdate = _context.Clients.FirstOrDefault(b => b.Token == item.Token);

            itemToUpdate.Name = item.Name;

            itemToUpdate.Description = item.Description;

            item.DateModified = DateTime.Now;

            _context.SaveChanges();

            return itemToUpdate;
        }

        public Client Delete(Guid token)
        {
            var itemToDelete = _context.Clients.FirstOrDefault(b => b.Token == token);

            var deletedItem = _context.Clients.Remove(itemToDelete);

            _context.SaveChanges();

            return deletedItem;
        }

        public IEnumerable<Client> List()
        {
            var items = _context.Clients.Take(1);

            return items;
        }

        public Client Get(Guid token)
        {
            var item = _context.Clients.ToList().FirstOrDefault(b => b.Token == token);

            return item;
        }
    }
}
