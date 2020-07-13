using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}