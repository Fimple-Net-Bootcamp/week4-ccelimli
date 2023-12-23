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
    public class TrainingMapPetManager : ITrainingMapPetService
    {
        ITrainingMapPetDal _TrainingMapPetDal;
        IMapper _mapper;

        public TrainingMapPetManager(ITrainingMapPetDal trainingMapPetDal, IMapper mapper)
        {
            _TrainingMapPetDal = trainingMapPetDal;
            _mapper = mapper;
        }

        public IResult Add(AddTrainingMapPetRequest addTrainingMapPetRequest)
        {
            TrainingMapPet trainingMapPet = _mapper.Map<TrainingMapPet>(addTrainingMapPetRequest);
            _TrainingMapPetDal.Add(trainingMapPet);
            return new SuccessResult("Success");
        }

        public IDataResult<List<GetTrainingMapPetResponse>> GetByPetId(int petId)
        {
            try
            {
                var result = Check(petId);
                if (result.Success != true)
                {
                    return new ErrorDataResult<List<GetTrainingMapPetResponse>>(result.Message);
                }
                return new SuccessDataResult<List<GetTrainingMapPetResponse>>(_TrainingMapPetDal.GetByPetId(petId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<GetTrainingMapPetResponse>>(ex.Message);
            }
        }

        public IDataResult<List<GetTrainingMapPetResponse>> GetDetails()
        {
            try
            {
                return new SuccessDataResult<List<GetTrainingMapPetResponse>>(_TrainingMapPetDal.GetDetail(), "Success");
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetTrainingMapPetResponse>>(ex.Message);
            }
        }

        public IResult Check(int id)
        {
            try
            {
                var result = _TrainingMapPetDal.Get(pet => pet.Id == id);
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

