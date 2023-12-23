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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class HealthStatusManager : IHealthStatusService
    {
        IHealthStatusDal _healthStatusDal;
        IMapper _mapper;

        public HealthStatusManager(IHealthStatusDal healthStatusDal, IMapper mapper)
        {
            _healthStatusDal = healthStatusDal;
            _mapper = mapper;
        }

        public IResult Add(AddHealthStatusRequest addHealthStatusRequest)
        {
            try
            {
                HealthStatus healthStatus=_mapper.Map<HealthStatus>(addHealthStatusRequest);
                _healthStatusDal.Add(healthStatus);
                return new SuccessResult(Messages.HealthStatusAdded);
            }catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public IResult Delete(int healthStatusId)
        {
            try
            {
                var result = Check(healthStatusId);
                if (result.Success == false)
                {
                    return new ErrorResult(result.Message);
                }
                HealthStatus healthStatus = _healthStatusDal.Get(healthStatus => healthStatus.Id == healthStatusId);
                _healthStatusDal.Delete(healthStatus);
                return new SuccessResult(Messages.HealthStatusDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<GetHealthStatusResponse>> GetAll()
        {
            try
            {
                List<GetHealthStatusResponse> result = _mapper.Map<List<GetHealthStatusResponse>>(_healthStatusDal.GetAll());
                return new SuccessDataResult<List<GetHealthStatusResponse>>(result,Messages.HealthStatusesListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetHealthStatusResponse>>(ex.Message);
            }
        }

        public IDataResult<GetHealthStatusResponse> GetById(int healthStatusId)
        {
            try
            {
                GetHealthStatusResponse getHealthStatusResponse = _mapper.Map<GetHealthStatusResponse>(_healthStatusDal.Get(healtStatus => healtStatus.Id == healthStatusId));
                var result = Check(healthStatusId);
                if (result.Success == false)
                {
                    return new ErrorDataResult<GetHealthStatusResponse>(result.Message);
                }
                return new SuccessDataResult<GetHealthStatusResponse>(getHealthStatusResponse, Messages.HealthStatusListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<GetHealthStatusResponse>(ex.Message);
            }
        }

        public IResult Update(UpdateHealthStatusRequest updateHealthStatusRequest)
        {
            try
            {
                var result = Check(updateHealthStatusRequest.Id);
                if (result.Success == false)
                {
                    return new ErrorResult(result.Message);
                }
                HealthStatus healthStatus = _mapper.Map<HealthStatus>(updateHealthStatusRequest);
                _healthStatusDal.Update(healthStatus);
                return new SuccessResult(Messages.HealthStatusUpdated);
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
                var result = _healthStatusDal.Get(food => food.Id == id);
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

        public IDataResult<List<GetHealthStatusDetail>> getHealthStatusDetails()
        {
            try
            {
                return new SuccessDataResult<List<GetHealthStatusDetail>>(_healthStatusDal.getHealthStatusDetails(),Messages.HealthStatusesListed);
            }
            catch (Exception error)
            {

                return new ErrorDataResult<List<GetHealthStatusDetail>>(error.Message);
            }
        }
    }
}
