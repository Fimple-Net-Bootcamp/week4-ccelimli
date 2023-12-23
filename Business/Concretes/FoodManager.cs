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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class FoodManager : IFoodService
    {
        IFoodDal _foodDal;
        IMapper _mapper;

        public FoodManager(IFoodDal foodDal, IMapper mapper)
        {
            _foodDal = foodDal;
            _mapper = mapper;
        }

        public IResult Add(AddFoodRequest addFoodRequest)
        {
            CheckByName(addFoodRequest.Name);
            Food food = _mapper.Map<Food>(addFoodRequest);
            _foodDal.Add(food);

            return new SuccessResult("Success");
        }

        public IResult Delete(int foodId)
        {
            try
            {
                Food food = _foodDal.Get(food => food.Id == foodId);
                _foodDal.Delete(food);
                return new SuccessResult(Messages.FoodDeleted);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
        public IDataResult<List<GetFoodResponse>> GetAll()
        {
            try
            {
                List<GetFoodResponse> result = _mapper.Map<List<GetFoodResponse>>(_foodDal.GetAll());
                return new SuccessDataResult<List<GetFoodResponse>>(result, Messages.FoodsListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetFoodResponse>>(ex.Message);
            }
        }

        public IDataResult<GetFoodResponse> GetById(int foodId)
        {
            try
            {
                var result = Check(foodId);
                if (result.Success == false)
                {
                    return new ErrorDataResult<GetFoodResponse>(result.Message);
                }
                GetFoodResponse getFoodResponse = _mapper.Map<GetFoodResponse>(_foodDal.Get(food => food.Id == foodId));
                return new SuccessDataResult<GetFoodResponse>(getFoodResponse, Messages.FoodListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<GetFoodResponse>(ex.Message);
            }
        }

        public IResult Update(UpdateFoodRequest updateFoodRequest)
        {
            try
            {
                var result = Check(updateFoodRequest.Id);
                if (result.Success == false)
                {
                    return new ErrorResult(result.Message);
                }
                Food food= _mapper.Map<Food>(updateFoodRequest);
                _foodDal.Update(food);
                return new SuccessResult(Messages.FoodUpdated);
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
                var result = _foodDal.Get(food => food.Id == id);
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
                var result = _foodDal.Get(food => food.Name == name);
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
