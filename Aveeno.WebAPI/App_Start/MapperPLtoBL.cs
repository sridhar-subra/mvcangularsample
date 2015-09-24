using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientBlDto = BusinessLibrary.Patient;
using LogBlDto = BusinessLibrary.Log;

namespace Aveeno.WebAPI
{
    public class MapperPlToBlProfile:Profile
    {
        private const string profileName = "MapperPlToBlProfile";
        protected override void Configure()
        {
            CreateMap<PatientBlDto, Patient>().WithProfile(profileName);               
            CreateMap<Patient,PatientBlDto>().WithProfile(profileName);
            CreateMap<LogBlDto, Log>();
        }
    }
}
