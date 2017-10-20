using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimeSheetManagment.Data;
using TimeSheetManagment.DataAccess.Abstracts;

namespace TimeSheetmanagment.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private TimeSheetManagmentDBContext _context;
        private IRepositoryBase<Project> _repository;
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(TimeSheetManagmentDBContext context,
            IRepositoryBase<Project> repository,
            ILogger<ProjectsController> logger)
        {
            _context = context;
            _repository = repository;
            _logger = logger;

        }
        [HttpGet(Name = "Projects")]
        public async Task<IActionResult> GetAsync()
        {

            _logger.LogInformation("Start Getting projects");
            try
            {
                var result = new TimeSheetManagment.DataAccess.DAL.DataAccessLayerBase<Project>(_context);
                var res = await result.GetAllAsync();
                _logger.LogInformation("Complete Getting projects");
                return Ok(res.AsEnumerable());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fail to get projects{ex.Message}");
                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Project project)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (await _repository.SaveAsync(project))
                {
                    var newUrl = Url.Link("Projects", new { Id = project.Id });
                    return Created(newUrl, project);
                };

            }
            catch
            {
                return BadRequest();
            }
            return BadRequest();

        }

    }
}