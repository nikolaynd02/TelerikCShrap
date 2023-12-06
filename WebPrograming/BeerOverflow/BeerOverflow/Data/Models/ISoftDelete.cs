namespace BeerOverflow.Data.Models
{
    public interface ISoftDelete
    {
        public bool IsDeleted {  get; set; }

        public void Undo()
        {
            IsDeleted = false;
        }
    }
}
