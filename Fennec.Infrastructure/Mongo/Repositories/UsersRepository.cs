using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fennec.Core.Entities.Users;
using Fennec.Core.Repositories;
using Fennec.Infrastructure.Mongo.Documents;
using Fennec.Infrastructure.Mongo.Extensions;
using MongoDB.Driver;

namespace Fennec.Infrastructure.Mongo.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<UserDocument> _users;

        public UsersRepository(IMongoClient client)
        {
            _users = client.GetDatabase("Fennec2").GetCollection<UserDocument>("users");
        }

        public async Task<RegisteredUser> Find(Guid id)
        {
            var documents = await _users.Find(u => u.Id == id).FirstOrDefaultAsync();
            return documents.AsEntity();
        }

        public async Task<IEnumerable<RegisteredUser>> Find()
        {
            var documents = await _users.Find(_=> true).ToListAsync();
            return documents.AsEntity();
        }

        public async Task Save(RegisteredUser t)
        {
            var document = t.AsDocument();
            await _users.InsertOneAsync(document);
        }
    }
}