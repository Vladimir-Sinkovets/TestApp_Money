using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp_Money.UseCases.Features.Categories.Commands.AddCategory
{
    public class AddCategoryCommand : IRequest<Guid>
    {
        public string UserId { get; set; }
        public string CategoryName { get; set; }
    }
}
