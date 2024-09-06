﻿using ASP.Aplication.DTO;
using ASP.Aplication.DTO.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Aplication.UseCasesAp.QueryAp.Contact
{
    public interface IGetContactQuery : IQuery<PagedResponseDto<ContactDto>, SearchContactDto>
    {
    }
}
