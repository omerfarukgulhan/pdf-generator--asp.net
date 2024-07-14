using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPhoneService
    {
        IDataResult<List<Phone>> GetAll();
        IDataResult<Phone> GetById(int phoneId);
        IResult Add(Phone phone);
        IResult Update(Phone phone);
        IResult Delete(Phone phone);
    }
}
