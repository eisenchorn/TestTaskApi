using System;
using System.Collections.Generic;

namespace TestTaskApi.Dto
{
    public class CompanyBaseDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }
    }

    public class CompanyDto : CompanyBaseDto
    {
        public List<PayerDto> Payers { get; set; }

        public CountryDto Country { get; set; }

        public ContactInfoDto CompanyContactInfo { get; set; }

        public List<ManagerBaseDto> Managers { get; set; }
    }
}