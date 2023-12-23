﻿using Core.Utilities.Results.Abstracts;
using Entity.Requests;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ITrainingService
    {
        IResult Add(AddTrainingRequest addTrainingRequest);
        IResult Delete(int trainingId);
        IDataResult<List<GetAllTrainingResponse>> GetAll();
        IDataResult<GetAllTrainingResponse> GetById(int id);
        IResult Update(UpdateTrainingRequest updateTrainingRequest);
    }
}
