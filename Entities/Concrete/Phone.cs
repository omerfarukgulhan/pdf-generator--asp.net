using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Phone : IEntity
    {
        public int PhoneId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
