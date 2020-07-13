using System;
using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Manager
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CompanyManager> CompanyManagers { get; set; }
    }
}