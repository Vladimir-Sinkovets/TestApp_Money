using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp_Money.UseCases.Features.Records.Commands.CreateRecord
{
    public class CreateRecordCommand : IRequest<Guid>
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public string UserId { get; set; }

    }
}
