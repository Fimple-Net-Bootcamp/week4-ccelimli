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
    public interface ISocialInteractionService
    {
        IResult Add(AddSocialInteractionRequest addSocialInteraction);
        IResult Delete(int socialInteraction);
        IDataResult<List<GetSocialInteractionResponse>> GetAll();
        IDataResult<GetSocialInteractionResponse> GetById(int id);
        IResult Update(UpdateSocialInteractionRequest updateSocialInteractionRequest);
    }
}
