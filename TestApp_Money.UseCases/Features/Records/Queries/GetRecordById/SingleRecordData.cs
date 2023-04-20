using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp_Money.Entites.Models;

namespace TestApp_Money.UseCases.Features.Records.Queries.GetRecordById
{
    public class SingleRecordData
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
    }
}
