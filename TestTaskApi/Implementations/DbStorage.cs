using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using TestTaskApi.Dto;

namespace TestTaskApi.Implementations
{
    /// <summary>
    /// Этот класс напрашивается на разбитие на подклассы по сущностям, с которыми они работают. 
    /// </summary>
    public class DbStorage
    {
        private readonly CompanyContext _dbContext;
        private readonly IMapper _mapper;

        public DbStorage(CompanyContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            var companies = _dbContext.Companies.Include(x => x.Country)
                .Include(x => x.ContactInfo)
                .Include(x => x.Payers)
                .Include(x => x.CompanyManagers).ThenInclude(x => x.Manager).AsQueryable();
            var result = _mapper.Map<List<CompanyDto>>(companies.ToList());
            return result;
        }

        public Guid AddNewCompany(CompanyDto companyDto)
        {
            var result = Guid.Empty;
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var companyId = AddCompany(companyDto);
                var contactInfoId = AddOrUpdateCompanyContactInfo(companyDto.CompanyContactInfo, companyId);
                if (companyDto.Managers != null)
                {
                    foreach (var manager in companyDto.Managers)
                    {
                        var managerId = AddManager(manager);
                        var companyManagerId = AddCompanyManager(companyId, managerId);
                    }
                }

                if (companyDto.Payers != null)
                {
                    foreach (var payer in companyDto.Payers)
                    {
                        AddPayerToCompany(payer, companyId);
                    }
                }

                result = companyId;
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }

            return result;
        }

        public bool EditCompany(CompanyDto companyDto)
        {
            if (companyDto.Id == null)
                return false;

            using var transaction = _dbContext.Database.BeginTransaction();
            var dbCompany = _dbContext.Companies
                .Include(x => x.ContactInfo)
                .FirstOrDefault(x => x.Id == companyDto.Id);
            if (dbCompany == null)
            {
                throw new Exception($"Company with id {companyDto.Id} not found");
            }

            try
            {
                if (companyDto.Country != null && _dbContext.Countries.FirstOrDefault(x => x.Code == companyDto.Country.Code) != null)
                {
                    dbCompany.CountryCode = companyDto.Country.Code;
                }

                if (companyDto.CompanyContactInfo != null)
                {
                    AddOrUpdateCompanyContactInfo(companyDto.CompanyContactInfo, companyDto.Id.Value);
                }

                if (!string.IsNullOrEmpty(companyDto.Name))
                {
                    dbCompany.Name = companyDto.Name;
                }
                _dbContext.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        public CompanyDto GetCompany(Guid id)
        {
            var company = _dbContext.Companies.Include(x => x.Country)
                .Include(x => x.ContactInfo)
                .Include(x => x.Payers)
                .Include(x => x.CompanyManagers).ThenInclude(x => x.Manager).FirstOrDefault(x => x.Id == id);
            var result = _mapper.Map<CompanyDto>(company);
            return result;
        }

        public bool DeletePayerFromCompany(Guid companyId, Guid payerId)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var company = _dbContext.Companies.Include(x => x.Payers).FirstOrDefault(x => x.Id == companyId);
                var payer = company?.Payers.FirstOrDefault(x => x.Id == payerId);
                if (payer != null)
                {
                    _dbContext.Payers.Remove(payer);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool EditPayer(PayerDto payerDto)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var payer = _dbContext.Payers.FirstOrDefault(x => x.Id == payerDto.Id);
                if (payer != null)
                {
                    payer.Name = payerDto.Name;
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool EditManager(ManagerDto managerDto)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var manager = _dbContext.Managers.FirstOrDefault(x => x.Id == managerDto.Id);
                if (manager != null)
                {
                    manager.Name = managerDto.Name;
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        public IEnumerable<ManagerDto> GetManagers()
        {
            var managers = _dbContext.Managers
                .Include(x => x.CompanyManagers)
                    .ThenInclude(x => x.Company)
                .AsQueryable();
            return _mapper.Map<List<ManagerDto>>(managers.ToList());
        }

        public ManagerDto GetManager(Guid id)
        {
            var manager = _dbContext.Managers
                .Include(x => x.CompanyManagers)
                .ThenInclude(x => x.Company)
                .FirstOrDefault(x => x.Id == id);
            return _mapper.Map<ManagerDto>(manager);
        }

        public bool DeleteManager(Guid id)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var manager = _dbContext.Managers.FirstOrDefault(x => x.Id == id);
                if (manager != null)
                {
                    var cms = _dbContext.CompanyManagers.Where(x => x.ManagerId == id);
                    _dbContext.RemoveRange(cms);
                    _dbContext.Remove(manager);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool UnassignManagerFromCompany(Guid companyId, Guid managerId)
        {
            var cm = _dbContext.CompanyManagers.FirstOrDefault(x => x.CompanyId == companyId && x.ManagerId == managerId);
            if (cm != null)
            {
                _dbContext.Remove(cm);
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool AssignManagerToCompany(Guid companyId, Guid managerId)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var manager = _dbContext.Managers.FirstOrDefault(x => x.Id == managerId);
                if (manager == null)
                {
                    transaction.Rollback();
                    return false;
                }
                AddCompanyManager(companyId, manager.Id);
                transaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        public Guid AddNewManager(ManagerBaseDto manager)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var id = AddManager(manager);
                transaction.Commit();
                return id;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return Guid.Empty;
            }
        }

        public Guid AddNewPayer(PayerDto payerDto, Guid companyId)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var id = AddPayerToCompany(payerDto, companyId);
                transaction.Commit();
                return id;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                return Guid.Empty;
            }
        }

        public bool DeleteCompany(Guid companyId)
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var company = _dbContext.Companies
                    .Include(x => x.Payers)
                    .Include(x => x.CompanyManagers)
                    .Include(x => x.ContactInfo)
                    .FirstOrDefault(x => x.Id == companyId);

                if (company != null)
                {
                    _dbContext.RemoveRange(company.Payers);
                    _dbContext.RemoveRange(company.CompanyManagers);
                    _dbContext.Remove(company.ContactInfo);
                    _dbContext.Remove(company);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    return false;
                }

            }
            catch (Exception e)
            {
                transaction.Rollback();
                return false;
            }
        }

        //Все методы использовать с транзакциями
        #region Private
        private Guid AddCompany(CompanyDto companyDto)
        {
            var countryCode = companyDto.Country.Code;
            var country = _dbContext.Countries.FirstOrDefault(x => x.Code == countryCode);
            if (country == null)
            {
                throw new Exception("Incorrect country code specified");
            }
            var company = new Company
            {
                CountryCode = companyDto.Country.Code,
                Name = companyDto.Name
            };
            _dbContext.Companies.Add(company);
            _dbContext.SaveChanges();
            return company.Id;
        }
        private Guid AddOrUpdateCompanyContactInfo(ContactInfoDto contactInfoDto, Guid companyId)
        {
            if (contactInfoDto == null)
                return Guid.Empty;
            var contactInf = _dbContext.ContactInfos.FirstOrDefault(x => x.CompanyId == companyId);
            if (contactInf == null)
            {
                contactInf = new ContactInfo
                {
                    Phone = contactInfoDto.Phone,
                    Email = contactInfoDto.Email,
                    CompanyId = companyId
                };
                _dbContext.ContactInfos.Add(contactInf);
            }
            else
            {
                contactInf.Phone = contactInfoDto.Phone;
                contactInf.Email = contactInfoDto.Email;
            }

            _dbContext.SaveChanges();
            return contactInf.Id;
        }

        private Guid AddManager(ManagerBaseDto managerDto)
        {
            var manager = _dbContext.Managers.FirstOrDefault(x => x.Id == managerDto.Id);
            if (manager == null)
            {
                var newManager = new Manager
                {
                    Name = managerDto.Name
                };
                _dbContext.Managers.Add(newManager);
                _dbContext.SaveChanges();

                return newManager.Id;
            }

            return manager.Id;
        }

        private Guid AddPayerToCompany(PayerDto payerDto, Guid companyId)
        {
            var payer = _dbContext.Payers.FirstOrDefault(x => x.Id == payerDto.Id);
            if (payer == null)
            {
                var newPayer = new Payer
                {
                    CompanyId = companyId,
                    Name = payerDto.Name
                };
                _dbContext.Payers.Add(newPayer);
                _dbContext.SaveChanges();

                return newPayer.Id;
            }

            return Guid.Empty;

        }

        private bool AddCompanyManager(Guid companyId, Guid managerId)
        {
            //проверяем, что такого еще нет
            var cm = _dbContext.CompanyManagers.FirstOrDefault(x =>
                x.CompanyId == companyId &&
                x.ManagerId == managerId);
            if (cm == null)
            {
                var companyManager = new CompanyManager
                {
                    CompanyId = companyId,
                    ManagerId = managerId
                };
                _dbContext.CompanyManagers.Add(companyManager);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        #endregion
    }
}