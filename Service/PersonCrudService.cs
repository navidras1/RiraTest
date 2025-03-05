using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Repository;
using DataAccess.RiraModels;
using Models;
using Models.Request;
using Models.Response;

namespace Service
{
    public interface IPersonCrudService
    {
        AddPersonResponse AddPerson(AddPersonRequest request);
        public GetAllPersonsResponse GetAllPersons();
        public ResponseMessage DeletePerson(DeletePersonRequest request);
        public ResponseMessage UpdatePerson(UpdatePersonRequest request);
    }

    public class PersonCrudService : IPersonCrudService
    {
        private IRiraRepository<Person> _person;
        private IValidation _validation;

        public PersonCrudService(IRiraRepository<Person> person, IValidation validation)
        {
            _person = person;
            _validation = validation;
        }

        public AddPersonResponse AddPerson(AddPersonRequest request)
        {
            AddPersonResponse response = new AddPersonResponse();
            var theDate = DateTimeOffset.FromUnixTimeSeconds(request.BirthDate.Value);
            

            try
            {

                if (string.IsNullOrWhiteSpace(request.FirstName))
                {
                    response.Message = "first name can not be empty";
                    response.IsSuccess = false;
                    return response;
                }
                if (string.IsNullOrWhiteSpace(request.LastName))
                {
                    response.Message = "last name can not be empty";
                    response.IsSuccess = false;
                    return response;
                }

                var nationalCodeValidatoinRes= _validation.NationalCodeValidation(request.NationalCode);

                if (nationalCodeValidatoinRes.IsSuccess == false) { 
                
                    response.Message = nationalCodeValidatoinRes.Message;
                    response.IsSuccess = false;
                    return response;
                }

                if (request.BirthDate == null)
                {
                    response.Message = "birthdate must have value";
                    response.IsSuccess = false;
                    return response;
                }

                Person person = new Person()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    NationalCode = request.NationalCode,
                    birthDate = theDate,
                };

                

                var addRes = _person.Add(person);
                response.Id = addRes.Id;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.IsSuccess = false;
            }

            return response;

        }

        public GetAllPersonsResponse GetAllPersons()
        {

            GetAllPersonsResponse response = new();
            try
            {
                var persons = _person.GetAll().ToList();
                response.Persons = persons;
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;


        }
        public ResponseMessage DeletePerson(DeletePersonRequest request)
        {
            ResponseMessage response = new ResponseMessage();

            try
            {
                var foundPerson = _person.GetById(request.Id);
                if (foundPerson == null)
                {
                    response.Warnings.Add("The Id not found");
                }
                else
                {
                    _person.RemoveById(request.Id);
                }
            }
            catch (Exception ex)
            {

                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public ResponseMessage UpdatePerson(UpdatePersonRequest request)
        {
            ResponseMessage response = new ResponseMessage();

            

            try
            {

                if (string.IsNullOrWhiteSpace(request.FirstName))
                {
                    response.Message = "first name can not be empty";
                    response.IsSuccess = false;
                    return response;
                }
                if (string.IsNullOrWhiteSpace(request.LastName))
                {
                    response.Message = "last name can not be empty";
                    response.IsSuccess = false;
                    return response;
                }

                var nationalCodeValidatoinRes = _validation.NationalCodeValidation(request.NationalCode);

                if (nationalCodeValidatoinRes.IsSuccess == false)
                {

                    response.Message = nationalCodeValidatoinRes.Message;
                    response.IsSuccess = false;
                    return response;
                }

                if (request.BirthDate == null)
                {
                    response.Message = "birthdate must have value";
                    response.IsSuccess = false;
                    return response;
                }

                var theDate = DateTimeOffset.FromUnixTimeSeconds(request.BirthDate);
                var foundPerson = _person.GetById(request.Id);
                if (foundPerson == null)
                {
                    response.Warnings.Add($"{request.Id} was not found");
                    return response;
                }


                foundPerson.FirstName = request.FirstName;
                foundPerson.LastName = request.LastName;

                foundPerson.birthDate = theDate;
                foundPerson.NationalCode = request.NationalCode;
                

                _person.Update(foundPerson);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
                
            }


            return response;
        }
    }
}
