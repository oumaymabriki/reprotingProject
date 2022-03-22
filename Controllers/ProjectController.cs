using DataLayers.Core;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reprotingProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProjectController: Controller
    {
        private readonly ServiceProject serviceProject;
        public ProjectController(ServiceProject _serviceProject) 
        {
            serviceProject = _serviceProject;
        }
        [HttpGet("getAll")]
        public ActionResult<List<Project>> Get() => Ok(serviceProject.GetAll());
        [HttpGet("{id}", Name ="GetbyId")]
        public ActionResult<Project> getbyId(string id)
        {
            var proj = Ok(serviceProject.GetById(id));
            if(proj== null)
            {
                return NotFound();
            }
            return proj;
        }
        [HttpPost("Add")]
        public ActionResult AddProject(Project proj)
        {
            serviceProject.Create(proj);
            return CreatedAtRoute("getAll",new {id=proj.IdProject },proj);
        }
       [HttpPut("update")]
       public ActionResult UpdateProject(Project proj)
        {
            return Ok(serviceProject.Update(proj));
        }
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteProject(string id)
        {
            serviceProject.Remove(id);
            return NoContent();
        }
    }
}
