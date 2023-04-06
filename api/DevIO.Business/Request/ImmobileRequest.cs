namespace DevIO.Business.Request
{
    public class ImmobileRequest : Request
    {
        public int? Id { get; set; }
        public string? Reference { get; set; }
        public decimal? Price{ get; set; } 
        public string? Description { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public int? Neighborhood { get; set; }
        public int? City { get; set; }
        public int? UF { get; set; }
        public string? Complement { get; set; }
        public string? Number { get; set; }
        public string? Image { get; set; }        
        public List<string>? Gallery { get; set; }
    }
}
