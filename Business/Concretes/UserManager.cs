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

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(AddUserValidator))]
        public IResult Add(AddUserRequest addUserRequest)
        {
            var resultByEmail=CheckByEmail(addUserRequest.Email);
            var resultByPhoneNumber=CheckByPhoneNumber(addUserRequest.PhoneNumber);
            if (resultByEmail.Success==false || resultByPhoneNumber.Success==false)
            {
                return new ErrorResult(Messages.ExistRecord);
            }
            User user = _mapper.Map<User>(addUserRequest);
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int id)
        {
            User user = _userDal.Get(user => user.Id == id);
            var result = Check(user.Id);
            if (result.Success == false)
            {
                return new ErrorResult(result.Message);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<GetUserResponse>> GetAll()
        {
            try
            {
                List<GetUserResponse> result = _mapper.Map<List<GetUserResponse>>(_userDal.GetAll());
                return new SuccessDataResult<List<GetUserResponse>>(result, Messages.UsersListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetUserResponse>>(ex.Message);
            }
        }

        public IDataResult<GetUserResponse> GetById(int userId)
        {
            try
            {
                GetUserResponse getUserResponses = _mapper.Map<GetUserResponse>(_userDal.Get(user => user.Id == userId));
                var result =Check(userId);
                if (result.Success == false)
                {
                    return new ErrorDataResult<GetUserResponse>(result.Message);
                }
                return new SuccessDataResult<GetUserResponse>(getUserResponses, Messages.UserListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<GetUserResponse>(ex.Message);
            }
        }

        [ValidationAspect(typeof(AddUserValidator))]
        public IResult Update(UpdateUserRequest updateUserRequest)
        {
            try
            {
                User user = _userDal.Get(u => u.Id == updateUserRequest.Id);
                var result = Check(user.Id);
                if (result.Success == false)
                {
                    return new ErrorResult(result.Message);
                }
                _userDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }


        public IDataResult<List<GetAllUserResponse>> GetAllUserDetails()
        {
           try {
                return new SuccessDataResult<List<GetAllUserResponse>>(_userDal.getAllUserResponses(), Messages.UsersListed);
            }
            catch (Exception ex)
            {

                return new ErrorDataResult<List<GetAllUserResponse>>(ex.Message);
            }
        }
        public IResult Check(int id)
        {
            try
            {
                var result = _userDal.Get(user => user.Id == id);
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

        public IResult CheckByEmail(string email)
        {
            try
            {
                var result = _userDal.Get(user => user.Email == email);
                if (result == null)
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

        public IResult CheckByPhoneNumber(string phoneNumber)
        {
            try
            {
                var result = _userDal.Get(user => user.PhoneNumber == phoneNumber);
                if (result == null)
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
