﻿using Core.Utilities.Results.Abstracts;
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
    public interface ISocialInteractionMapPetService
    {
        IResult Add(AddSocialInteractionMapPetRequest addSocialInteractionRequest);
        IDataResult<List<GetSocialInteractionMapDetails>> GetDetails();
        IDataResult<List<GetSocialInteractionMapDetails>> GetByPetId(int petId);
    }
}
