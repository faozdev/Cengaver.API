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
        }
    }

}
