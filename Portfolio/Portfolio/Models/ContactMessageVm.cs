namespace Portfolio.Models
{
    public class ContactMessageVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
    }
}
