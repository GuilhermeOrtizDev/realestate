namespace DevIO.Infrastructure.Responses
{
    public class BaseResponse
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsActive { get; set; }
    }
}
