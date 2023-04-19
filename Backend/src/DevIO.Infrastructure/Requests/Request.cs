namespace DevIO.Infrastructure.Requests
{
    public class Request
    {
        public int? Id { get; set; }
        public int? Take { get; set; }
        public int? Skip { get; set; }
        public List<OrderBy>? Orders { get; set; }
    }

    public class OrderBy
    {
        public string By { get; set; }

        public bool Desc { get; set; }

        public OrderBy()
        {
            Desc = false;
        }
    }
}
