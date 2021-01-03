namespace TodoApiWithMediatr.Services
{
    public class GetTodoItemByIdResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool isCompleted { get; set; }
        public string Description { get; set; }
    }
}