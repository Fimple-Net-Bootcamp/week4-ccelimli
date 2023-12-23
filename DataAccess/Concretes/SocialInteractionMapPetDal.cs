using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entity.Concretes;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class SocialInteractionMapPetDal : EntityRepositoryBase<SocialInteractionMapPet, PetCareContext>, ISocialInteractionMapPetDal
    {
        public List<GetSocialInteractionMapDetails> GetDetail()
        {
            using (PetCareContext context = new PetCareContext())
            {
                var GetSocialInteractionMapDetails = from socialInteractionMapPet in context.SocialInteractionMapPets
                                                     join pet in context.Pets
                                                     on socialInteractionMapPet.Id equals pet.Id
                                                     join destinationPet in context.Pets
                                                     on socialInteractionMapPet.DestinationPetId equals destinationPet.Id
                                                     join socialInteraction in context.SocialInteraction
                                                     on socialInteractionMapPet.SocialInteractionId equals socialInteraction.Id
                                                     select new GetSocialInteractionMapDetails
                                                     {
                                                         PetName = pet.PetName,
                                                         PetBreed = pet.PetBreed,
                                                         PetAge = pet.PetAge,
                                                         Gender = pet.Gender,
                                                         DestinationPetName = destinationPet.PetName,
                                                         DestinationPetBreed = destinationPet.PetBreed,
                                                         DestinationPetAge = destinationPet.PetAge,
                                                         DestinationGender = destinationPet.Gender,
                                                         SocialInteractionName = socialInteraction.Name
                                                     };
                return GetSocialInteractionMapDetails.ToList();
            }
        }

        public List<GetSocialInteractionMapDetails> GetByPetId(int petId)
        {
            using (PetCareContext context = new PetCareContext())
            {
                var GetSocialInteractionMapDetails = from socialInteractionMapPet in context.SocialInteractionMapPets
                                                     join pet in context.Pets
                                                     on socialInteractionMapPet.Id equals pet.Id
                                                     join destinationPet in context.Pets
                                                     on socialInteractionMapPet.DestinationPetId equals destinationPet.Id
                                                     join socialInteraction in context.SocialInteraction
                                                     on socialInteractionMapPet.SocialInteractionId equals socialInteraction.Id
                                                     where pet.Id == petId
                                                     select new GetSocialInteractionMapDetails
                                                     {
                                                         PetName = pet.PetName,
                                                         PetBreed = pet.PetBreed,
                                                         PetAge = pet.PetAge,
                                                         Gender = pet.Gender,
                                                         DestinationPetName = destinationPet.PetName,
                                                         DestinationPetBreed = destinationPet.PetBreed,
                                                         DestinationPetAge = destinationPet.PetAge,
                                                         DestinationGender = destinationPet.Gender,
                                                         SocialInteractionName = socialInteraction.Name
                                                     };
                return GetSocialInteractionMapDetails.ToList();
            }
        }
    }
}
