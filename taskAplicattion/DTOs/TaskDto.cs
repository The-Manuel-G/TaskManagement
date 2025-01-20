namespace TaskManagement.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        public  string StatusName { get; set; } = string.Empty;
    }
}
