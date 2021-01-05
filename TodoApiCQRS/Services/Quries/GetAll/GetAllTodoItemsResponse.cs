namespace TodoApiCQRS.Services
{
    public class GetAllTodoItemsResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool isCompleted { get; set; }
    }
}