using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Claims;
using TestApp_Money.UseCases.Features.Categories.Queries.GetAllCategoriesForUser;
using TestApp_Money.UseCases.Features.Records.Commands.CreateRecord;
using TestApp_Money.UseCases.Features.Records.Queries.GetRecordsByPages;
using TestApp_Money.Web.Models;

namespace TestApp_Money.Web.Controllers
{
    [Authorize]
    public class RecordController : BasicController
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public RecordController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ListAsync(int page)
        {
            var getRecordListQuery = new GetRecordsByPagesQuery()
            {
                ItemsPerPage = 15,
                PageNumber = page,
                UserId = UserId,
            };

            var listDto = (await _mediator.Send(getRecordListQuery))
                .OrderBy(r => r.CreatedDate)
                .ToList();

            var viewModel = new RecordListViewModel()
            {
                Records = _mapper.Map<List<RecordViewModel>>(listDto),
            };


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(AddRecordViewModel model)
        {
            var createRecordCommand = new CreateRecordCommand()
            {
                Description = model.Description,
                CreatedDate = model.CreatedDate,
                Category = model.Category,
                UserId = UserId,
                Value = model.Value,
            };

            _mediator.Send(createRecordCommand);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync()
        {
            var model = new AddRecordViewModel()
            {
                AllCategories = await GetAllCategoriesAsync(),
            };

            return View(model);
        }

        private async Task<IList<string>> GetAllCategoriesAsync()
        {
            var getAllCategoriesQuery = new GetAllCategoriesForUserQuery()
            {
                UserId = UserId,
            };

            var allCategories = await _mediator.Send(getAllCategoriesQuery);

            return allCategories.Select(c => c.Name).ToList();
        }
    }
}
