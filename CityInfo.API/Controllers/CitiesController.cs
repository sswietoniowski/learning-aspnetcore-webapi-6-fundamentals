﻿using CityInfo.API.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            // Status Codes:
            // Level 100 - Informational
            // Level 200 - OK (200 OK, 201 Created, 204 - No Content)
            // Level 300 - Redirected
            // Level 400 - Client's Error (400 Bad Request, 401 Not Authorized, 403 Forbidden, 404 Not Found, 409 Conflict)
            // Level 500 - Server's Error (500 Internal Server Error)

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(city => city.Id == id);

            if (city is null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}