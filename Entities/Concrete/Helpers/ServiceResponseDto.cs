using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Helpers
{
    public class ServiceResponseDto
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
