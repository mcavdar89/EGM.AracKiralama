using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Model.Dtos
{
    public class ResultDto<T> where T : class, new()
    {
        T? Data { get; set; }
        bool IsSuccess { get; set; }
        string? Message { get; set; }

        public static ResultDto<T> Success(T data, string? message = null)
        {
            var result = new ResultDto<T>()
            {
                IsSuccess = true,
                Data = data,
                Message = message
            };
            return result;
        }
        public static ResultDto<T> Error(string message, T? data = null)
        {
            var result = new ResultDto<T>()
            {
                IsSuccess = false,
                Data = data,
                Message = message
            };
            return result;
        }

    }
}
