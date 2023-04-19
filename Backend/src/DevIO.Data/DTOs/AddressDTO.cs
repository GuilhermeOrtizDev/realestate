namespace DevIO.Data.DTOs
{
    public class AddressDTO : BaseDTO
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string? Complement { get; set; }
        public string Number { get; set; }
        public int NeighborhoodId { get; set; }
        public int CityId { get; set; }
        public int UFId { get; set; }
        public NeighborhoodDTO Neighborhood { get; set; }
        public CityDTO City { get; set; }
        public UFDTO UF { get; set; }
        public ImmobileDTO Immobile { get; set; }
    }
}
