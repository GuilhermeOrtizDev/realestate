namespace DevIO.Data.DTOs
{
    public class GalleryDTO : BaseDTO
    {
        public string File { get; set; }
        public bool Emphasis { get; set; }
        public int ImmobileId { get; set; }
        public ImmobileDTO Immobile { get; set; }
    }
}
