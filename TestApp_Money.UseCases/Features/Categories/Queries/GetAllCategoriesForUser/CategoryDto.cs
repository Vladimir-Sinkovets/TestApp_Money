using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp_Money.Entites.Models;

namespace TestApp_Money.UseCases.Features.Categories.Queries.GetAllCategoriesForUser
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
