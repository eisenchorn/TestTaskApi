using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;

namespace TestTaskApi.Dto
{
    public class ManagerDto : ManagerBaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CompanyBaseDto> Companies { get; set; }
    }
    public class ManagerBaseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}