namespace CaptureDataAndNavigateFromSessionApp.Models
{
    /// <summary>
    /// Mentor is a foreign key in the Mentee table because the schema is designed so that a mentee can only have one mentor, but any mentor can have multiple mentees
    /// </summary>
    public class Mentor
    {
        public int MentorId { get; set; }
        public string? MentorName { get; set; }
        public string? MentorEmail { get; set; }
    }
}
