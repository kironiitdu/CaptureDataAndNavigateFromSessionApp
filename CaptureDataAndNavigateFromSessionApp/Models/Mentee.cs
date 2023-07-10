namespace CaptureDataAndNavigateFromSessionApp.Models
{
    /// <summary>
    /// Mentor is a foreign key in the Mentee table because the schema is designed so that a mentee can only have one mentor, but any mentor can have multiple mentees
    /// </summary>
    public class Mentee
    {
        public int MenteeId { get; set; }
        public string? MenteeName { get; set; }
        public string? MenteeEmail { get; set; }
        public int? MentorId { get; set; }
    }
}
