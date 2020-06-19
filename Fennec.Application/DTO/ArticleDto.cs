using System;
using System.Collections.Generic;
using Fennec.Core.Entities;
using Fennec.Core.Enums;

namespace Fennec.Application.DTO
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }
        public bool IsAdvertisementEnabled { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<Advertisement> Advertisements { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}