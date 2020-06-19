using System;

namespace Fennec.Core.Entities
{
    public class Category : IEntity
    {
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}