namespace Infrastructure.Model.Entities
{
    public abstract class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public byte StatusId { get; set; }
        public DateTime LastTransactionDate { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
