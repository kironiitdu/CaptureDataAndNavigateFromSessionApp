using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaptureDataAndNavigateFromSessionApp.Models
{
    public class MentorMenteeCustomModel
    {
        public Mentee? Mentee { get; set; }
        public int MentorId { get; set; }
        public IEnumerable<SelectListItem>? Mentors { get; set; }
       
    }
}
