﻿using Business.Localitation.Interface;
using Entity.Dto.Parameter;
using Entity.Model.Dto.Localitation;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Localitation.Implementation
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryBusiness _countryBusiness;

        public CountryController(ICountryBusiness countryBusiness)
        {
            _countryBusiness = countryBusiness;
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAll()
        {
            var result = await _countryBusiness.GetAll();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetById(int id)
        {
            var result = await _countryBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CountryDto>> Save([FromBody] CountryDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _countryBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CountryDto entity)
        {
            if (entity == null || id != entity.Id)
            {
                return BadRequest();
            }
            await _countryBusiness.Update(id, entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryBusiness.Delete(id);
            return NoContent();
        }
    }
}

