using System.Collections.Generic;
using System.Linq;
using Fennec.Application.DTO;
using Fennec.Core.Entities;

namespace Fennec.Application.Extensions.Content
{
    public static class CommentExtensions
    {
        public static CommentDto AsDto(this Comment comment)
            => new CommentDto
            {
                Body = comment.Body,
                Id = comment.Id,
                DateOfComment = comment.DateOfComment
            };

        public static IEnumerable<CommentDto> AsDto(this IEnumerable<Comment> comments)
            => comments.Select(AsDto);
    }
}