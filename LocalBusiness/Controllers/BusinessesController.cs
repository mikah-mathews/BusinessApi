using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocalBusiness.Models;
using LocalBusiness.Wrappers;
using LocalBusiness.Filter;
using LocalBusiness.Helpers;
using LocalBusiness.Services;

namespace LocalBusiness.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/Business")]
  [ApiController]
  public class BusinessesController : ControllerBase
  {
    private readonly LocalBusinessContext _db;
    private readonly IUriService uriService;

    public BusinessesController(LocalBusinessContext db, IUriService uriService)
    {
      _db = db;
      this.uriService = uriService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
    {
      var route = Request.Path.Value;
      var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
      var pagedData = await _db.Businesses
        .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
        .Take(validFilter.PageSize)
        .ToListAsync();
      var totalRecords = await _db.Businesses.CountAsync();
      var pagedResponse = PaginationHelper.CreatePagedResponse<Business>(pagedData, validFilter, totalRecords, uriService, route);
      return Ok(pagedResponse);
    } 

    [HttpPost]
    public async Task<ActionResult<Business>> Post(Business business)
    {
      _db.Businesses.Add(business);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetBusiness), new { id = business.BusinessId}, business);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Business>> GetBusiness(int id)
    {
      var business = await _db.Businesses.FindAsync(id);
      if (business == null)
      {
        return NotFound();
      }

      return Ok(new Response<Business>(business));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Business business)
    {
      if (id != business.BusinessId)
      {
        return BadRequest();
      }

      _db.Entry(business).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!BusinessExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBusiness(int id)
    {
      var business = await _db.Businesses.FindAsync(id);
      if (business == null)
      { 
        return NotFound();
      }

      _db.Businesses.Remove(business);
      await _db.SaveChangesAsync();
      return NoContent();
    }

    private bool BusinessExists(int id)
    { 
      return _db.Businesses.Any(e => e.BusinessId == id);
    }
  }
}