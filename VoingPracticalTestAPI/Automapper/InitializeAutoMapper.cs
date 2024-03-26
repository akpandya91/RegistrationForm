using AutoMapper;

namespace VoingPracticalTestAPI.Automapper
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
