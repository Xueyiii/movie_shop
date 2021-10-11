using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        
        [HttpPost]
        [Route("Movie")]
        public async Task<IActionResult> CreateMovie([FromBody] MovieDetailsRequestModel movieDetailsRequestModel)
        {
            var createdMovie = await _adminService.CreateMovie(movieDetailsRequestModel);
            return CreatedAtRoute("GetMovie", new { id = movieDetailsRequestModel.Id }, createdMovie);
        }
    }
}