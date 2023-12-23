using Core.Utilities.Results.Abstracts;
using Entity.Concretes;
using Entity.Requests;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IActivityService
    {
        IResult Add(AddActiviteRequest addActiviteRequest);
        IResult Delete(int activityId);
        IDataResult<List<GetActivityResponse>> GetAll();
        IDataResult<GetActivityResponse> GetById(int activityId);
        IDataResult<List<GetActivityDetails>> GetPetById(int petId);
        IResult Update(UpdateActiviyRequest updateActiviyRequest);
    }
}
