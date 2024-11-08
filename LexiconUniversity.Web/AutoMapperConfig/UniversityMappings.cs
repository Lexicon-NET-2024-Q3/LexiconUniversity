using AutoMapper;

namespace LexiconUniversity.Web.AutoMapperConfig
{
    public class UniversityMappings : Profile
    {
        public UniversityMappings()
        {
            CreateMap<Student, StudentCreateViewModel>().ReverseMap();

            CreateMap<Student, StudentIndexViewModel>()
                .ForMember(
                dest => dest.CourseInfos,
                opts => opts.MapFrom(src => src.Enrollments.Select(e => new CourseInfo
                {
                    Grade = e.Grade,
                    CourseName = e.Course.Title
                }))); 
        }
    }
}
