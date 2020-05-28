using System;
using System.Collections.Generic;
using BDVTest.BLL;
using BDVTest.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BSVTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSheetOneController : ControllerBase
    {
        private readonly IWorkSheetService _workSheetService;

        public WorkSheetOneController(IWorkSheetService workSheetService)
        {
            _workSheetService = workSheetService;
        }
        
        // GET api/workSheetOne?time=2020-05-27 20:30:00
        [HttpGet]
        public ActionResult<List<BaseWorkSheetDto>> Get([FromQuery] DateTime? time)  
        {
            try
            {
                return Ok(_workSheetService.ReadWorkSheetOneDataByTime(time));
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal API error");
            }
        }
        
        // PUT api/workSheetOne/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] WorkSheetOneDto workSheetOne)
        {
            try
            {
                return _workSheetService.UpdateWorkSheetOneData(id, workSheetOne) ? 
                    StatusCode(200, "WorkSheetOne updated successfully") : 
                    StatusCode(404, "WorkSheetOne NotFound");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal API error");
            }
        }
        
        // DELETE api/workSheetOne/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return _workSheetService.DeleteWorkSheetOneData(id) ? 
                    StatusCode(200, "WorkSheetOne deleted successfully") : 
                    StatusCode(404, "WorkSheetOne NotFound");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal API error");
            }
        }
    }
}