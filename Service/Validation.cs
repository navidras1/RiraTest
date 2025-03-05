using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service
{
    public interface IValidation
    {
        ResponseMessage NationalCodeValidation(string nationalcode);
    }

    public class Validation : IValidation
    {
        public ResponseMessage NationalCodeValidation(string nationalcode)
        {
            ResponseMessage response = new ResponseMessage();
            var checkDigit = Regex.IsMatch(nationalcode, @"^\d+$");
            if (!checkDigit)
            {
                response.Message = "National Code must be digit";
                response.IsSuccess = false;
            }
            if (nationalcode.Length != 10)
            {
                response.Message = "National Code must be 10 digits";
                response.IsSuccess = false;

            }

            return response;



        }
    }
}
