using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using vidly.DTO;
using vidly.Models;

namespace vidly.App_Start
{
    public class mappingprofile : Profile
    {

        public mappingprofile()
        {
            //domain to dto
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();

            //dto dto to domain
            Mapper.CreateMap<CustomerDTO, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore()) ;
           
        }
    }
}