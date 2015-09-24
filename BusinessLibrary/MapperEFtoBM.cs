using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientDalDto = DataAccessLibrary.Patient;
using LogDalDto = DataAccessLibrary.Log;

namespace BusinessLibrary
{
    public class MapperDalToBlPRofile:Profile
    {
        private const string profileName = "MapperDalToBlProfile";
        protected override void Configure()
        {
            CreateMap<PatientDalDto, Patient>().WithProfile(profileName)
                .ForMember(target => target.PatientId, opt => opt.MapFrom(src => src.id))
                .ForMember(target => target.Sex, opt => opt.MapFrom(src => src.SexOfThePatient));


            CreateMap<Patient,PatientDalDto>().WithProfile(profileName)
               .ForMember(target => target.id, opt => opt.MapFrom(src => src.PatientId))
               .ForMember(target => target.SexOfThePatient, opt => opt.MapFrom(src => src.Sex));

            CreateMap<LogDalDto, Log>();
        }
    }
}
