using AutoMapper;
using Entity.Concretes;
using Entity.Requests;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserRequest, User>().ReverseMap();

            CreateMap<AddActiviteRequest, Activity>().ReverseMap();
            CreateMap<AddSocialInteractionMapPetRequest, SocialInteractionMapPet>().ReverseMap();
            CreateMap<UpdateActiviyRequest, Activity>().ReverseMap();   

            CreateMap<GetUserResponse, User>().ReverseMap();
            CreateMap<GetUserPetResponse, Pet>().ReverseMap();  
            
            CreateMap<Pet, GetPetResponse>().ReverseMap();
            CreateMap<GetPetUserResponse, User>().ReverseMap();

            CreateMap<GetHealthStatusResponse, HealthStatus>().ReverseMap();
            CreateMap<GetHealthStatusPetResponse, Pet>().ReverseMap();

            CreateMap<GetFoodResponse, Food>().ReverseMap();
            CreateMap<GetFoodPetResponse, Pet>().ReverseMap();

            CreateMap<GetPetFoodResponse, Food>().ReverseMap();

            CreateMap<GetActivityResponse, Activity>().ReverseMap();
            CreateMap<GetActivityPetResponse, Pet>().ReverseMap();
            
            
            CreateMap<GetPetHealthStatusResponse, HealthStatus>().ReverseMap();

        }
    }
}
