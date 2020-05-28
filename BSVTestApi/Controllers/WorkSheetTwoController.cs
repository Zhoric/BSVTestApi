using System;
using System.Collections.Generic;
using BDVTest.BLL;
using BDVTest.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BSVTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkSheetTwoController : ControllerBase
    {
        private readonly IWorkSheetService _workSheetService;

        public WorkSheetTwoController(IWorkSheetService workSheetService)
        {
            _workSheetService = workSheetService;
        }
        
        // GET api/workSheetTwo?time=2020-05-27 20:30:00
        [HttpGet]
        public ActionResult<List<BaseWorkSheetDto>> Get([FromQuery] DateTime? time)  
        {
            return Ok(_workSheetService.ReadWorkSheetTwoDataByTime(time));
        }
        
        // PUT api/workSheetTwo/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] WorkSheetTwoDto workSheetTwo)
        {
            try
            {
                return _workSheetService.UpdateWorkSheetTwoData(id, workSheetTwo) ? 
                    StatusCode(200, "WorkSheetTwo updated successfully") : 
                    StatusCode(404, "WorkSheetTwo NotFound");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal API error");
            }
        }
        
                
        // DELETE api/workSheetTwo/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return _workSheetService.DeleteWorkSheetTwoData(id) ? 
                    StatusCode(200, "WorkSheetTwo deleted successfully") : 
                    StatusCode(404, "WorkSheetTwo NotFound");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal API error");
            }
        }
    }
}