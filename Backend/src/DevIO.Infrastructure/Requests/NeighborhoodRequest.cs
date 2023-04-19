namespace DevIO.Infrastructure.Requests
{
    public class NeighborhoodRequest : Request
    {
        public int? CityId { get; set; }
        public string? Description { get; set; }

    }
}
