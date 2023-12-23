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
    public interface IHealthStatusService
    {
        IResult Add(AddHealthStatusRequest addHealthStatusRequest);
        IResult Delete(int healthStatusId);
        IDataResult<List<GetHealthStatusResponse>> GetAll();
        IDataResult<GetHealthStatusResponse> GetById(int healthStatusId);
        IResult Update(UpdateHealthStatusRequest updateHealthStatusRequest);
        IDataResult<List<GetHealthStatusDetail>> getHealthStatusDetails();
    }
}
