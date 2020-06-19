using System.Collections.Generic;
using System.Linq;
using Fennec.Core.Entities;
using Fennec.Infrastructure.Mongo.Documents;

namespace Fennec.Infrastructure.Mongo.Extensions
{
    public static class CommentDocumentExtensions
    {
        public static Comment AsEntity(this CommentDocument commentDocument, UserDocument userDocument)
        {
            return Comment.Create(commentDocument.Id, commentDocument.Body, userDocument.AsEntity());
        }

        public static IEnumerable<Comment> AsEntity(this IEnumerable<CommentDocument> commentDocuments,
            UserDocument userDocument)
            => commentDocuments.Select(c => c.AsEntity(userDocument));

        public static CommentDocument AsDocument(this Comment comment)
            => new CommentDocument
            {
                Body = comment.Body,
                Id = comment.Id,
                DateOfComment = comment.DateOfComment
            };

        public static IEnumerable<CommentDocument> AsDocument(this IEnumerable<Comment> comments)
            => comments.Select(AsDocument);
    }
}