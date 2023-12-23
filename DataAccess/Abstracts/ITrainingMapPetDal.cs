using Core.DataAccess;
using Entity.Concretes;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ITrainingMapPetDal : IEntityRepository<TrainingMapPet>
    {
        List<GetTrainingMapPetResponse> GetDetail();
        List<GetTrainingMapPetResponse> GetByPetId(int petId);
    }
}
