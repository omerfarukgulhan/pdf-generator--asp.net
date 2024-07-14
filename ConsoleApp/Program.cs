using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPhoneDal efPhoneDal = new EfPhoneDal();
            Phone phone = efPhoneDal.Get(p => p.PhoneId == 1);
            Console.WriteLine(phone.PhoneId);
            Console.WriteLine(phone.Brand);
            Console.WriteLine(phone.Model);

            IPhoneService phoneService = new PhoneManager(efPhoneDal);
            List<Phone> phoneList = phoneService.GetAll().Data;

            foreach (var item in phoneList)
            {
                Console.WriteLine(item.PhoneId);
            }
        }
    }
}
