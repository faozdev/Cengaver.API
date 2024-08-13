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
        }
    }

}
