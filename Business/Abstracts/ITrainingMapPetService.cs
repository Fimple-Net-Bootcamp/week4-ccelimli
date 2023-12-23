using Core.Utilities.Results.Abstracts;
using Entity.Requests;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ITrainingMapPetService
    {
        IResult Add(AddTrainingMapPetRequest addTrainingMapPetRequest);
        IDataResult<List<GetTrainingMapPetResponse>> GetDetails();
        IDataResult<List<GetTrainingMapPetResponse>> GetByPetId(int petId);
    }
}
