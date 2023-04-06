namespace DevIO.Business.Response
{
    public class ImmobileResponse
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Reference { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string? Complement { get; set; }
        public string Number { get; set; }
        public string? Image { get; set; }
        public NeighborhoodResponse Neighborhood { get; set; }
        public CityResponse City { get; set; }
        public UFResponse UF { get; set; }
        public List<string>? Gallery { get; set; }
    }

}
