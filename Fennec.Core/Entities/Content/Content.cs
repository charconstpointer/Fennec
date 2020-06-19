using System;
using Fennec.Core.Enums;

namespace Fennec.Core.Entities.Content
{
    public abstract class Content : IEntity
    {
        public Guid Id { get; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Category Category { get; protected set; }
        public bool IsAdvertisementEnabled { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public ContentState State { get; set; }

        protected Content(Guid id, string title,
            string description, Category category, ContentState state, bool isAdvertisementEnabled = false,
            bool isDeleted = false)
        {
            Id = id;
            Title = title;
            Description = description;
            Category = category;
            IsAdvertisementEnabled = isAdvertisementEnabled;
            IsDeleted = isDeleted;
            State = state;
        }
    }
}