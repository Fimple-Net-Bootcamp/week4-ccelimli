using AutoMapper;
using Business.Abstracts;
using Business.Constant;
using Core.Utilities.Results.Abstracts;
using Core.Utilities.Results.Concretes;
using DataAccess.Abstracts;
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
    public class SocialInteractionManager : ISocialInteractionService
    {
        ISocialInteractionDal _socialInteractionDal;
        IMapper _mapper;

        public SocialInteractionManager(ISocialInteractionDal socialInteractionDal, IMapper mapper)
        {
            _socialInteractionDal = socialInteractionDal;
            _mapper = mapper;
        }

        public IResult Add(AddSocialInteractionRequest addSocialInteraction)
        {
            CheckByName(addSocialInteraction.Name);
            SocialInteraction socialInteraction= _mapper.Map<SocialInteraction>(addSocialInteraction);
            _socialInteractionDal.Add(socialInteraction);
            return new SuccessResult("Success");
        }

        public IResult Delete(int id)
        {
            try
            {
                SocialInteraction socialInteraction = _socialInteractionDal.Get(socialInteraction => socialInteraction.Id == id);
                _socialInteractionDal.Delete(socialInteraction);
                return new SuccessResult("Success");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
        public IDataResult<List<GetSocialInteractionResponse>> GetAll()
        {
            try
            {
                List<GetSocialInteractionResponse> result = _mapper.Map<List<GetSocialInteractionResponse>>(_socialInteractionDal.GetAll());
                return new SuccessDataResult<List<GetSocialInteractionResponse>>(result, "Success");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetSocialInteractionResponse>>(ex.Message);
            }
        }

        public IDataResult<GetSocialInteractionResponse> GetById(int id)
        {
            try
            {
                var result = Check(id);
                if (result.Success == false)
                {
                    return new ErrorDataResult<GetSocialInteractionResponse>(result.Message);
                }
                GetSocialInteractionResponse getAllTrainingResponse = _mapper.Map<GetSocialInteractionResponse>(_socialInteractionDal.Get(socialInteraction => socialInteraction.Id == id));
                return new SuccessDataResult<GetSocialInteractionResponse>(getAllTrainingResponse, "Success");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<GetSocialInteractionResponse>(ex.Message);
            }
        }

        public IResult Update(UpdateSocialInteractionRequest updateSocialInteractionRequest)
        {
            try
            {
                var result = Check(updateSocialInteractionRequest.Id);
                if (result.Success == false)
                {
                    return new ErrorResult(result.Message);
                }
                SocialInteraction socialInteraction = _mapper.Map<SocialInteraction>(updateSocialInteractionRequest);
                _socialInteractionDal.Update(socialInteraction);
                return new SuccessResult("Success");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Check(int id)
        {
            try
            {
                var result = _socialInteractionDal.Get(socialInteraction => socialInteraction.Id == id);
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

        public IResult CheckByName(string name)
        {
            try
            {
                var result = _socialInteractionDal.Get(training => training.Name == name);
                if (result != null)
                {
                    return new ErrorResult(Messages.ExistRecord);
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
