namespace Market.Application.Services.Queries.GetUsers
{
    public class ResultGetUsersDto
    {
        public List<GetUsersDto> Users { get; set; }
        public int Rows { get; set; }
    }
}
