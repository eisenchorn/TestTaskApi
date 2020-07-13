using System;

namespace DataAccessLayer.Entities
{
    public class Payer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CompanyId { get; set; }
    }
}