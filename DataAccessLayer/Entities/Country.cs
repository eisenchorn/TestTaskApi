using System;

namespace DataAccessLayer.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}