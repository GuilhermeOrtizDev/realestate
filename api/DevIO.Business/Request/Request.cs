namespace DevIO.Business.Request
{
    public class Request
    {
        public int? Amount { get; set; }
        public int? Page { get; set; }
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
