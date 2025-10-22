using Market.Application.Interfaces;
using Common;

namespace Market.Application.Services.Queries.GetUsers
{
    public class GetUsersService : IGetUsersServices
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
               _context = context;
        }
        public List<GetUsersDto> Execute(RequestGetUserDto request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;
            return users.ToPaged(request.Page, 20,out rowsCount).Select(p => new GetUsersDto
            { 
            Email = p.Email,
            FullName = p.FullName,
            Id = p.Id,
            }).ToList();
        }
    }
}
