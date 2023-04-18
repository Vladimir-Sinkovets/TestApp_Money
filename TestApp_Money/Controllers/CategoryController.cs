using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApp_Money.UseCases.Features.Categories.Commands.AddCategory;
using TestApp_Money.UseCases.Features.Categories.Queries.GetAllCategoriesForUser;
using TestApp_Money.Web.Models;

namespace TestApp_Money.Web.Controllers
{
    [Authorize]
    public class CategoryController : BasicController
    {
        private IMediator _mediator;
        private IMapper _mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync()
        {
            var getAllCategoriesQuery = new GetAllCategoriesForUserQuery()
            {
                UserId = UserId,
            };

            var allCategories = await _mediator.Send(getAllCategoriesQuery);

            var model = new AddCategoryViewModel()
            {
                Categories = _mapper.Map<List<CategoryData>>(allCategories),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCategoryViewModel model)
        {
            var addCategoryCommand = new AddCategoryCommand()
            {
                CategoryName = model.CategoryName,
                UserId = UserId,
            };

            await _mediator.Send(addCategoryCommand);


            var getAllCategoriesQuery = new GetAllCategoriesForUserQuery()
            {
                UserId = UserId,
            };

            var allCategories = await _mediator.Send(getAllCategoriesQuery);
            
            model.Categories = _mapper.Map<List<CategoryData>>(allCategories);

            return View(model);
        }
    }
}
