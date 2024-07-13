using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

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

            Console.WriteLine("Hello World!");
        }
    }
}
