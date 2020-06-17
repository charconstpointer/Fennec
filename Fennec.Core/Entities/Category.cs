using System;

namespace Fennec.Core.Entities
{
    public class Category : IEntity
    {
        public Category(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}