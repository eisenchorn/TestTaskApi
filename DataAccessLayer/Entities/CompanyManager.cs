using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class CompanyManager
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public Guid ManagerId { get; set; }
        public Manager Manager { get; set; }
    }
}
