using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Company
    {
        /// <summary>
        /// Вообще лучше не выставлять наружу первичные ключи базы данных
        /// Для внешних идентификаторов следовало бы завести отдельное поле, но в рамках задачи этим можно пренебречь
        /// </summary>
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public Country Country { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public List<Payer> Payers { get; set; }
        public List<CompanyManager> CompanyManagers { get; set; }
    }
}
