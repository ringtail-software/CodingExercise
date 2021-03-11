using System;

namespace CodingExercise.Models
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
        public Result(){}
        public override bool Equals(object obj)
        {
            if (!(obj is Result<T>))
                return false;
            var val = (Result<T>)obj;
            return Success == val.Success && ErrorMessage == val.ErrorMessage && Data.Equals(val.Data);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Success, ErrorMessage, Data);
        }
    }
}
