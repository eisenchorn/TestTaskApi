using System;
using Microsoft.AspNetCore.Mvc;
using TestTaskApi.Dto;
using TestTaskApi.Implementations;

namespace TestTaskApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly DbStorage _storage;

        public ManagersController(DbStorage storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Получить список всех менеджеров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetManagers()
        {
            var result = _storage.GetManagers();
            return Ok(result);
        }

        /// <summary>
        /// Получить информацию о конкретном менеджере
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetManager(Guid id)
        {
            var result = _storage.GetManager(id);
            return Ok(result);
        }

        /// <summary>
        /// Удалить менеджера по указанному id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteManager(Guid id)
        {
            var result = _storage.DeleteManager(id);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Добавить нового менеджера, не привязывая его ни к одной компании
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddManager(ManagerBaseDto manager)
        {
            var result = _storage.AddNewManager(manager);
            if (result != Guid.Empty)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Изменить информацию о менеджере
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult EditManager(ManagerDto manager)
        {
            var result = _storage.EditManager(manager);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Назначить менеджера в компанию
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [HttpPost]
        [HttpPost("{managerId}/companies/{companyId}")]
        public IActionResult AssignManagerToCompany(Guid companyId, Guid managerId)
        {
            var result = _storage.AssignManagerToCompany(companyId, managerId);
            if (result)
                return Ok();
            else
                return Conflict();
        }

        /// <summary>
        /// Удалить назначение менеджера в компанию
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="managerId"></param>
        /// <returns></returns>
        [HttpDelete("{managerId}/companies/{companyId}")]
        public IActionResult UnassignManagerFromCompany(Guid companyId, Guid managerId)
        {
            var result = _storage.UnassignManagerFromCompany(companyId, managerId);
            if (result)
                return Ok();
            else
                return Conflict();
        }
    }
}