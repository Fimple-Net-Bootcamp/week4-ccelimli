using AutoMapper;
using Business.Abstracts;
using Business.Constant;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entity.Concretes;
using Entity.Requests;
using Entity.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class SocialInteractionMapPetManager : ISocialInteractionMapPetService
    {
        ISocialInteractionMapPetDal _SocialInteractionMapPetDal;
        IMapper _mapper;

        public SocialInteractionMapPetManager(ISocialInteractionMapPetDal socialInteractionMapPetDal, IMapper mapper)
        {
            _SocialInteractionMapPetDal = socialInteractionMapPetDal;
            _mapper = mapper;
        }

        public IResult Add(AddSocialInteractionMapPetRequest addSocialInteractionRequest)
        {
            SocialInteractionMapPet socialInteractionMapPet = _mapper.Map<SocialInteractionMapPet>(addSocialInteractionRequest);
            _SocialInteractionMapPetDal.Add(socialInteractionMapPet);
            return new SuccessResult("Success");
        }

        public IDataResult<List<GetSocialInteractionMapDetails>> GetByPetId(int petId)
        {
            try
            {
                var result= Check(petId);
                if (result.Success != true) {
                    return new ErrorDataResult<List<GetSocialInteractionMapDetails>>(result.Message);
                }
                return new SuccessDataResult<List<GetSocialInteractionMapDetails>>(_SocialInteractionMapPetDal.GetByPetId(petId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<GetSocialInteractionMapDetails>>(ex.Message);
            }
        }

        public IDataResult<List<GetSocialInteractionMapDetails>> GetDetails()
        {
            try
            {
                return new SuccessDataResult<List<GetSocialInteractionMapDetails>>(_SocialInteractionMapPetDal.GetDetail(), "Success");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetSocialInteractionMapDetails>>(ex.Message); 
            }
        }

        public IResult Check(int id)
        {
            try
            {
                var result = _SocialInteractionMapPetDal.Get(pet => pet.Id == id);
                if (result == null)
                {
                    return new ErrorResult(Messages.NotFound);
                }
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
