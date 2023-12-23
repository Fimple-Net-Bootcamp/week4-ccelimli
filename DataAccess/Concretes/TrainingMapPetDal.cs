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
    public class TrainingMapPetDal : EntityRepositoryBase<TrainingMapPet, PetCareContext>, ITrainingMapPetDal
    {
        public List<GetTrainingMapPetResponse> GetDetail()
        {
            using (PetCareContext context = new PetCareContext())
            {
                var GetTrainingMapPetResponse = from trainingMapPet in context.TrainingMapPets
                                                join pet in context.Pets
                                                on trainingMapPet.PetId equals pet.Id
                                                join training in context.Trainings
                                                on trainingMapPet.TrainingId equals training.Id
                                                select new GetTrainingMapPetResponse
                                                {
                                                    PetName = pet.PetName,
                                                    PetBreed = pet.PetBreed,
                                                    PetAge = pet.PetAge,
                                                    Gender = pet.Gender,
                                                    TrainingName = training.Name
                                                };
                return GetTrainingMapPetResponse.ToList();
            }
        }

        public List<GetTrainingMapPetResponse> GetByPetId(int petId)
        {
            using (PetCareContext context = new PetCareContext())
            {
            
                    var GetTrainingMapPetResponse = from trainingMapPet in context.TrainingMapPets
                                                    join pet in context.Pets
                                                    on trainingMapPet.PetId equals pet.Id
                                                    join training in context.Trainings
                                                    on trainingMapPet.TrainingId equals training.Id
                                                    where pet.Id == petId
                                                    select new GetTrainingMapPetResponse
                                                    {
                                                        PetName = pet.PetName,
                                                        PetBreed = pet.PetBreed,
                                                        PetAge = pet.PetAge,
                                                        Gender = pet.Gender,
                                                        TrainingName = training.Name
                                                    };
                    return GetTrainingMapPetResponse.ToList();
          
            }
        }
    }
}
