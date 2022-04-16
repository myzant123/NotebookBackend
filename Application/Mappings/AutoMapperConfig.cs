using Application.DTO;
using Application.DTO.CategoryDto;
using AutoMapper;
using Domain.Entity;

namespace Application.Mappings;

public static class AutoMapperConfig
{
    public static IMapper Initialize() => new MapperConfiguration(cfg =>
    {
        #region Notes

        cfg.CreateMap<Note, NoteDto>()
            .ForMember(dest => dest.LastModified, act => act.MapFrom(src => src.Detail.LastModified));
        cfg.CreateMap<NoteDtoCreate, Note>();
        cfg.CreateMap<NoteDtoUpdate, Note>();
        cfg.CreateMap<IEnumerable<Note>, ListNotesDto>()
            .ForMember(dest => dest.Notes, act => act.MapFrom(src => src))
            .ForMember(dest => dest.Count, act => act.MapFrom(src => src.Count()));

        #endregion

        #region Categories

        cfg.CreateMap<Category, CategoryDto>();
        cfg.CreateMap<CategoryDtoCreate, Category>();
        cfg.CreateMap<CategoryDtoUpdate, Category>();

        #endregion

    }).CreateMapper();
}