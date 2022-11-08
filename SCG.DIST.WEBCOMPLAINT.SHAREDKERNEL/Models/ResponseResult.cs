using Microsoft.AspNetCore.Mvc.ModelBinding;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Constant;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Models
{
    public class ResponseResult<T>
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public List<string> Errors { get; set; }
        public List<ValidationError> ModelErrors { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
        public int? Total { get; set; }

        public static ResponseResult<T> Success<T>(T data)
        {
            return new ResponseResult<T>() { Data = data, IsSuccess = true, Status = 200 };
        }

        public static ResponseResult<T> Success<T>(T data, int total)
        {
            return new ResponseResult<T>() { Data = data, IsSuccess = true, Status = 200, Total = total };
        }

        public static ResponseResult<T> Success()
        {
            return new ResponseResult<T>() { IsSuccess = true, Status = 200 };
        }
        public static ResponseResult<T> Fail<T>(T data, int status)
        {
            return new ResponseResult<T>() { Data = data, IsSuccess = false, Status = status };
        }
        public static ResponseResult<List<string>> Fail(List<string> errors)
        {
            return new ResponseResult<List<string>>() { Errors = errors, IsSuccess = false, Status = 400 };
        }
        public static ResponseResult<T> Fail()
        {
            return new ResponseResult<T>() { IsSuccess = false, Status = 400 };
        }

        public static ResponseResult<T> Fail(string msg)
        {
            return new ResponseResult<T>() { IsSuccess = false, Status = APPCONSTANT.EXCEPTION.SYSTEM_ERROR, Error = msg };
        }
        public static ResponseResult<T> Fail(string msg, int status)
        {
            if (status == 0)
                status = 400;
            return new ResponseResult<T>() { IsSuccess = false, Status = status, Error = msg };
        }

        public static ResponseResult<List<string>> Fail(ModelStateDictionary modelState)
        {
            var errors = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
            return new ResponseResult<List<string>>() { ModelErrors = errors, IsSuccess = false, Status = 400 };
        }

        public static ResponseResult<T> UnAuth()
        {
            return new ResponseResult<T>() { IsSuccess = false, Status = 401 };

        }


    }

}
