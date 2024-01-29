using Entities.Concrete;
using Entities.Concrete.Dtos.SalaryDetails;
using Entities.Concrete.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISalaryDetailsRepo : IEntityRepository<SalaryDetails>
    {
        public Task<ServiceResponseDto> PostSalaryDetailsSP(AddSalaryDetailsDto dto);

    }
}
