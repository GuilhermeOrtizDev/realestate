namespace DevIO.Business.DTOs
{
    public abstract class BaseDTO : DTO
    {
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
