using Microsoft.AspNetCore.Mvc.Rendering;

namespace LexiconUniversity.Web.Services
{
    public interface IGetCoursesService
    {
        Task<IEnumerable<SelectListItem>> GetCoursesAsync();
    }
}