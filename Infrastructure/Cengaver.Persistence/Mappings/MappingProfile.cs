using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Cengaver.Domain;
using Cengaver.Dto;

namespace Cengaver.Services.Mappings
{
    

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // All mappings
            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Permission, PermissionDto>().ReverseMap();
            CreateMap<PermissionDto, Permission>();

            CreateMap<GuardDutyCreateDto, GuardDuty>();
            CreateMap<GuardDuty, GuardDutyDto>();
            CreateMap<GuardDutyDto, GuardDuty>();

            CreateMap<GuardDutyBreak, GuardDutyBreakDto>()
            .ReverseMap(); 

            CreateMap<GuardDutyBreakType, GuardDutyBreakTypeDto>()
                .ReverseMap();

            CreateMap<UserCommunication, UserCommunicationDto>().ReverseMap();

            CreateMap<UserTransactionLog, UserTransactionLogDto>().ReverseMap(); 
            CreateMap<UserTransactionLogCreateDto, UserTransactionLog>();

            CreateMap<TeamTransactionLogDto, TeamTransactionLog>()
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId)); // Mapping nested objects

            CreateMap<TeamTransactionLog, TeamTransactionLogDto>()
                 .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.TeamId)); // Mapping nested objects

            CreateMap<TeamDto, Team>(); // Ensure mapping is defined
            CreateMap<Team, TeamDto>();

            CreateMap<UserTeamDto, UserIsInTeamRelation>()
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));
            CreateMap<UserIsInTeamRelation, UserTeamDto>()
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate));

            CreateMap<UserTeamDto, UserIsInTeamRelation>().ReverseMap();

            CreateMap<GuardDutyNoteDto, GuardDutyNote>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Adjust as needed
            .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.GuardDutyId, opt => opt.MapFrom(src => src.GuardDutyId))
            .ForMember(dest => dest.NoteTypeId, opt => opt.MapFrom(src => src.NoteTypeId))
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore()); // or configure as needed

            CreateMap<GuardDutyNote, GuardDutyNoteDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.GuardDutyId, opt => opt.MapFrom(src => src.GuardDutyId))
                .ForMember(dest => dest.NoteTypeId, opt => opt.MapFrom(src => src.NoteTypeId))
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore()); // or configure as needed

        }
    }

}
