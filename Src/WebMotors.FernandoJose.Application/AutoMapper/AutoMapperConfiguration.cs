using AutoMapper;

namespace WebMotors.FernandoJose.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new ModelToViewModel());
                ps.AddProfile(new ViewModelToModel());
            });
        }
    }
}
