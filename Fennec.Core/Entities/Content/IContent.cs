﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fennec.Core.Entities.Content
{
    public interface IContent
    {
        IReadOnlyCollection<string> Tags { get; }
        IReadOnlyCollection<Advertisement> Advertisements { get; }
        IReadOnlyCollection<Comment> Comments { get; }
        void AddComment(Comment comment);
    }
}