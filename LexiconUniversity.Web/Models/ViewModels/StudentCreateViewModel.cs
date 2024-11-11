using LexiconUniversity.Web.Validations;

namespace LexiconUniversity.Web.Models.ViewModels
{
    public class StudentCreateViewModel
    {
        public string NameFirstName { get; set; }
        [CheckLastName]
        public string NameLastName { get; set; }
        public string Email { get; set; }
        [CheckStreetNr(10)]
        public string AddressStreet { get; set; }
        public string AddressZipCode { get; set; }
        public string AddressCity { get; set; }

        public IEnumerable<int> SelectedCourses { get; set; } = new List<int>(); 
    }
}
