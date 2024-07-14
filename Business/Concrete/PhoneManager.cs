using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Business.Concrete
{
    public class PhoneManager : IPhoneService
    {
        private IPhoneDal _phondeDal;

        public PhoneManager(IPhoneDal phoneDal)
        {
            _phondeDal = phoneDal;
        }

        public IResult Add(Phone phone)
        {
            _phondeDal.Add(phone);
            return new SuccessResult("Phone added");
        }

        public IResult Delete(Phone phone)
        {
            _phondeDal.Delete(phone);
            return new SuccessResult("Phone added");
        }

        public IDataResult<List<Phone>> GetAll()
        {
            return new SuccessDataResult<List<Phone>>(_phondeDal.GetAll(), "Phones fetched");
        }

        public IDataResult<Phone> GetById(int phoneId)
        {
            return new SuccessDataResult<Phone>(_phondeDal.Get(p => p.PhoneId == phoneId), "Phone fetched");
        }

        public IResult Update(Phone phone)
        {
            _phondeDal.Update(phone);
            return new SuccessResult("Phone added");
        }
    }
}
