namespace DevIO.Infrastructure.Requests
{
    public class CityRequest : Request
    {
        public int? UFId { get; set; }
        public string? Description { get; set; }
    }
}
