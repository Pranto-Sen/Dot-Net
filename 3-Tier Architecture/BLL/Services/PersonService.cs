using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PersonService
    {
       public static List<PersonDTO> Get()
        {
            var data = PersonRepo.Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<PersonDTO>>(data);
        }

        public static bool Add(PersonDTO p)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDTO, Person>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Person>(p);
            return PersonRepo.Add(data);
        }
         
    }
}
