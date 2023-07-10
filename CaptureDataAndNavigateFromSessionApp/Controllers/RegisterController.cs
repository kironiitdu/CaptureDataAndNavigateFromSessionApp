using CaptureDataAndNavigateFromSessionApp.ExtensionMethods;
using CaptureDataAndNavigateFromSessionApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace CaptureDataAndNavigateFromSessionApp.Controllers
{
    public class RegisterController : Controller
    {
        public static List<Mentor> listOfMentor = new List<Mentor>()
        {
            new Mentor() { MentorId =101, MentorName ="C# Mentor", MentorEmail ="csmentor@outlook.com"},
            new Mentor() { MentorId =102, MentorName ="SQL Mentor", MentorEmail ="sqlmentor@outlook.com"},
            new Mentor() { MentorId =103, MentorName ="JS Mentor", MentorEmail ="jsmentor@outlook.com"},
           
        };
        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult RegisterNewMentee(Mentee mentee)
        {
            KeepMenteeInformation(mentee);

            return RedirectToAction("MapMentor");
        }

        public IActionResult MapMentor()
        {
            var getMenteeObjectFromSession = HttpContext.Session.GetComplexObjectSession<RegisterModelObject>("RegisterMentorMentees");

          

            var mentorMenteeViewModel = new MentorMenteeCustomModel();

            if (getMenteeObjectFromSession != null)
            {
                mentorMenteeViewModel.Mentee = getMenteeObjectFromSession!.Mentees!.FirstOrDefault();
                mentorMenteeViewModel.Mentors = listOfMentor.Select(i => new SelectListItem
                {
                    Text = i.MentorName,
                    Value = i.MentorId.ToString()
                });
            }
            return View(mentorMenteeViewModel);
        }

        /// <summary>
        /// Save mentee along with mentor object in database 
        /// </summary>
        /// <param name="mentorMenteeObject"></param>
        /// <returns></returns>
        public IActionResult MapMentorAndMentee(MentorMenteeCustomModel mentorMenteeObject)
        {
          

            return RedirectToAction("Index");
        }
        private void KeepMenteeInformation(Mentee mentee)
        {

            var getMenteeObject = HttpContext.Session.GetComplexObjectSession<RegisterModelObject>("RegisterMentorMentees");
            if (getMenteeObject != null)
            {
                getMenteeObject!.Mentees!.Add(mentee);
                HttpContext.Session.SetComplexObjectSession("RegisterMentorMentees", getMenteeObject);
            }
            else
            {
                getMenteeObject = new RegisterModelObject();
                getMenteeObject!.Mentees!.Add(mentee);
                HttpContext.Session.SetComplexObjectSession("RegisterMentorMentees", getMenteeObject);
            }
        }
    }
}
