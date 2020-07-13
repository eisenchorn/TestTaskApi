using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TestTaskApi.Dto;
using TestTaskApi.Implementations;

namespace TestTaskApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly DbStorage _storage;

        public CompaniesController(DbStorage storage)
        {
            _storage = storage;
        }

        #region Company CRUD

        /// <summary>
        /// Получить список компаний
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_storage.GetCompanies());
        }

        /// <summary>
        /// Получить данные о конкретной компании
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetCompany(Guid id)
        {
            var result = _storage.GetCompany(id);
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        /// <summary>
        /// Добавить новую компанию
        /// </summary>
        /// <param name="companyDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddCompany([FromBody] CompanyDto companyDto)
        {
            var result = _storage.AddNewCompany(companyDto);
            return Ok(result);
        }

        /// <summary>
        /// Изменить информацию о существующей компании(за исключением информации о плательщиках и менеджерах)
        /// </summary>
        /// <param name="companyDto"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult EditCompany([FromBody] CompanyDto companyDto)
        {
            var result = _storage.EditCompany(companyDto);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Удалить компанию
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("{companyId}")]
        public IActionResult DeleteCompany(Guid companyId)
        {
            var result = _storage.DeleteCompany(companyId);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        #endregion

        #region Managers
        /// <summary>
        /// Назначить менеджера в компанию
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpPost("{companyId}/managers/{managerId}")]
        public IActionResult AssignManagerToCompany(Guid managerId, Guid companyId)
        {
            var result = _storage.AssignManagerToCompany(companyId, managerId);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Снять менеджера с назначения в компании
        /// </summary>
        /// <param name="managerId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("{companyId}/managers/{managerId}")]
        public IActionResult UnassignManagerFromCompany(Guid managerId, Guid companyId)
        {
            var result = _storage.UnassignManagerFromCompany(companyId, managerId);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        #endregion

        #region Payers
        //их можно убрать в отдельный контроллер. но в рамках данной задачи плательщики не явлюятся самостоятельной сущностью без компании
        //так что я решил их оставить тут

        /// <summary>
        /// Удалить плательщика компании
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="payerId"></param>
        /// <returns></returns>
        [HttpDelete("{companyId}/payers/{payerId}")]
        public IActionResult DeletePayerFromCompany(Guid companyId, Guid payerId)
        {
            var result = _storage.DeletePayerFromCompany(companyId, payerId);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Изменить данные плательщика компании(в данном случае только имя)
        /// </summary>
        /// <param name="payerDto"></param>
        /// <returns></returns>
        [HttpPut("{companyId}/payers")]
        public IActionResult EditPayer([FromBody] PayerDto payerDto)
        {
            var result = _storage.EditPayer(payerDto);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Добавить нового плательщика компании
        /// </summary>
        /// <param name="payerDto"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpPost("{companyId}/payers")]
        public IActionResult AddPayer([FromBody] PayerDto payerDto, Guid companyId)
        {
            var result = _storage.AddNewPayer(payerDto, companyId);
            if (result != Guid.Empty)
                return Ok();
            else
                return Conflict();
        }

        #endregion
    }
}