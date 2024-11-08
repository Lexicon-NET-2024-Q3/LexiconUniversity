using AutoMapper;

namespace LexiconUniversity.Web.AutoMapperConfig
{
    public class UniversityMappings : Profile
    {
        public UniversityMappings()
        {
            CreateMap<Student, StudentCreateViewModel>().ReverseMap(); 
        }
    }
}
