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
    public class TrainingManager : ITrainingService
    {
        ITrainingDal _trainingDal;
        IMapper _mapper;

        public TrainingManager(ITrainingDal trainingDal, IMapper mapper)
        {
            _trainingDal = trainingDal;
            _mapper = mapper;
        }

        public IResult Add(AddTrainingRequest addTrainingRequest)
        {
            CheckByName(addTrainingRequest.Name);
            Training training= _mapper.Map<Training>(addTrainingRequest);
            _trainingDal.Add(training);
            return new SuccessResult("Success");
        }

        public IResult Delete(int trainingId)
        {
            try
            {
                Training training= _trainingDal.Get(training => training.Id == trainingId);
                _trainingDal.Delete(training);
                return new SuccessResult("Success");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
        public IDataResult<List<GetAllTrainingResponse>> GetAll()
        {
            try
            {
                List<GetAllTrainingResponse> result = _mapper.Map<List<GetAllTrainingResponse>>(_trainingDal.GetAll());
                return new SuccessDataResult<List<GetAllTrainingResponse>>(result,"Success");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetAllTrainingResponse>>(ex.Message);
            }
        }

        public IDataResult<GetAllTrainingResponse> GetById(int id)
        {
            try
            {
                var result = Check(id);
                if (result.Success == false)
                {
                    return new ErrorDataResult<GetAllTrainingResponse>(result.Message);
                }
                GetAllTrainingResponse getAllTrainingResponse= _mapper.Map<GetAllTrainingResponse>(_trainingDal.Get(training => training.Id == id));
                return new SuccessDataResult<GetAllTrainingResponse>(getAllTrainingResponse, "Success");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<GetAllTrainingResponse>(ex.Message);
            }
        }

        public IResult Update(UpdateTrainingRequest updateTrainingRequest)
        {
            try
            {
                var result = Check(updateTrainingRequest.Id);
                if (result.Success == false)
                {
                    return new ErrorResult(result.Message);
                }
                Training training = _mapper.Map<Training>(updateTrainingRequest);
                _trainingDal.Update(training);
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
                var result = _trainingDal.Get(training => training.Id == id);
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
                var result = _trainingDal.Get(training => training.Name == name);
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
