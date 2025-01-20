namespace TaskManagement.DTOs
{
    public class CreateTaskDto
    {
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        public int StatusId { get; set; }

    }
}
