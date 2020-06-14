using Microsoft.AspNet.Identity;
using NguyenVanKhai_lab456.DTOs;
using NguyenVanKhai_lab456.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NguyenVanKhai_lab456.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend (AttendanceDto atendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Ateendances.Any(a => a.AttendeeId == userId && a.CourseID == atendanceDto.CourseId))
                return BadRequest("The attendance alreary exists!");
            var attendance = new Attendance
            {
                CourseID = atendanceDto.CourseId,
                AttendeeId = userId
            };
          
            _dbContext.Ateendances.Add(attendance);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
