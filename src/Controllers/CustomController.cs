using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeautifulRestApi.Infrastructure;
using BeautifulRestApi.Models;
using BeautifulRestApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BeautifulRestApi.Controllers
{
    [Route("/[controller]")]
    public class CustomController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly PagingOptions _defaultPagingOptions;

        public CustomController(
            ICommentService commentService,
            IOptions<PagingOptions> defaultPagingOptionsAccessor)
        {
            _commentService = commentService;
            _defaultPagingOptions = defaultPagingOptionsAccessor.Value;
        }

        [HttpGet(Name = nameof(GetCommentsAsync))]
        [ValidateModel]
        public async Task<IActionResult> GetCommentsAsync(
            [FromQuery] PagingOptions pagingOptions,
            CancellationToken ct)
        {
            pagingOptions.Offset = pagingOptions.Offset ?? _defaultPagingOptions.Offset;
            pagingOptions.Limit = pagingOptions.Limit ?? _defaultPagingOptions.Limit;

            var conversations = await _commentService.GetCommentsAsync(null, pagingOptions, ct);

            var collection = CollectionWithPaging<CommentResource>.Create(
                Link.ToCollection(nameof(GetCommentsAsync)),
                conversations.Items.ToArray(),
                conversations.TotalSize,
                pagingOptions);

            return Ok(collection);
        }
    }
}
