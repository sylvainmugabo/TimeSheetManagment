using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManagment.Data;
using TimeSheetManagment.DataAccess.Abstracts;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace TimeSheetManagment.Api.Controllers
{
    [EnableCors("CorsPolicy")] 
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
        // GET api/values
        [HttpGet(Name = "Projects")]
        public async Task<IActionResult> GetAsync()
        {

            _logger.LogInformation("Start Getting projects");
            try
            {
                var result = new DataAccess.DAL.DataAccessLayerBase<Project>(_context);
                var res = await result.GetAllAsync();
                _logger.LogInformation("Complete Getting projects");
                return Ok(res.AsEnumerable());
            }
            catch(Exception ex)
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

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
   
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var oldProject = await _repository.GetAsync(id);
                if (oldProject == null) return NotFound($"Could not find Project with id of {id}");

                if (await _repository.DeleteAsync(oldProject))
                {
                    return Ok();
                };
               
            }
            catch (Exception)
            {
            }

            return BadRequest("Could not delete Project");
        }
    }
}
