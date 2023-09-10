using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConutBackend.Base.Services.Articles.Models;
using ConutBackend.Base.Services.Articles;
using ConutBackend.Base.Filtering;

namespace ConutBackend.Controllers.Articles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public Task<SingleModel> GetSingle(int id)
            => _mediator.Send(new GetSingleArticleQuery
            {
                Id = id
            });

        [HttpPost("search")]
        public Task<PagedResult<PagedModel>> Search(PagedQueryParams<FilterModel> query)
            => _mediator.Send(new GetPagedArticleQuery
            {
                Query = query
            });
    }
}
