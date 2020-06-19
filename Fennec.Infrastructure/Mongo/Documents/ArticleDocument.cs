using System;
using System.Collections.Generic;
using Fennec.Core.Entities;
using Fennec.Core.Enums;

namespace Fennec.Infrastructure.Mongo.Documents
{
    public class ArticleDocument
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public string Body { get; set; }
        public bool IsAdvertisementEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public ContentState State { get; set; }
        public ISet<string> Tags { get; set; }
        public ISet<Advertisement> Advertisements { get; set; }
        public ISet<Comment> Comments { get; set; }
    }
}