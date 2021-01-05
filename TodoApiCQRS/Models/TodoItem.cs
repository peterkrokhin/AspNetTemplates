namespace TodoApiCQRS.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool isCompleted { get; set; }
        public string Description { get; set; }
        public string InternalUseField { get; set; }
    }
}