using AutoMapper;
using Business.Abstracts;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class ActivityManager : IActivityService
    {
        IActivityDal _activityDal;
        IMapper _mapper;
        public ActivityManager(IActivityDal activityDal, IMapper mapper)
        {
            _activityDal = activityDal;
            _mapper = mapper;
        }

        //Add
        [ValidationAspect(typeof(AddActiviteRequest))]
        public IResult Add(AddActiviteRequest addActiviteRequest)
        {
            var result= CheckByType(addActiviteRequest.Type);
            if (result.Success==false) {
                return new ErrorResult(result.Message);
            }
            Activity activity = _mapper.Map<Activity>(addActiviteRequest);
            _activityDal.Add(activity);
            return new SuccessResult(Messages.ActivityAdded);
        }

        public IResult Delete(int activityId)
        {
            try
            {
                Activity activity = _activityDal.Get(activity=>activity.Id == activityId);
                _activityDal.Delete(activity);
                return new SuccessResult(Messages.ActivityDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<GetActivityResponse>> GetAll()
        {
            try
            {
                List<GetActivityResponse> result = _mapper.Map<List<GetActivityResponse>>(_activityDal.GetAll());
                return new SuccessDataResult<List<GetActivityResponse>>(result,Messages.ActivitiesListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetActivityResponse>>(ex.Message);
            }
        }

        public IDataResult<GetActivityResponse> GetById(int activityId)
        {
            try
            {
                var Result = Check(activityId);
                GetActivityResponse getActivityResponse = _mapper.Map<GetActivityResponse>(_activityDal.Get(activity => activity.Id == activityId));
                if (Result.Success == false)
                {
                    return new ErrorDataResult<GetActivityResponse>(Result.Message);
                }
                return new SuccessDataResult<GetActivityResponse>(getActivityResponse, Messages.ActivityListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<GetActivityResponse>(ex.Message);
            }
        }

        [ValidationAspect(typeof(UpdateActivityValidator))]
        public IResult Update(UpdateActiviyRequest updateActiviyRequest)
        {
            try
            {
                var Result = Check(updateActiviyRequest.Id);
                if (Result.Success==false)
                {
                    return new ErrorResult(Result.Message);
                }

                Activity activity = _mapper.Map<Activity>(updateActiviyRequest);
                _activityDal.Update(activity);
                return new SuccessResult(Messages.ActivityUpdated);
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
                var result = _activityDal.Get(activity => activity.Id == id);
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

        public IResult CheckByType(string type)
        {
            try
            {
                var result = _activityDal.Get(activity => activity.Type == type);
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

        public IDataResult<List<GetActivityDetails>> GetPetById(int petId)
        {
            try
            {
                return new SuccessDataResult<List<GetActivityDetails>>(_activityDal.GetActivityDetails(petId),Messages.ActivitiesListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetActivityDetails>>(ex.Message);
            }
        }
    }
}
