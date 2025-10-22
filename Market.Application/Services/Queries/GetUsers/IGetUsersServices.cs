using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Market.Application.Services.Queries.GetUsers
{
    public interface IGetUsersServices
    {
        List<GetUsersDto> Execute(RequestGetUserDto request);
    }
}
