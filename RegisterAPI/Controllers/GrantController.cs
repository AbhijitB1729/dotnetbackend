
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterAPI.Models;

namespace RegisterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrantController : Controller
    {
        private readonly DetailsAPIDbContext detailsDb;

        public GrantController(DetailsAPIDbContext detailsDb)
        {
            this.detailsDb=detailsDb;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDetail()
        {
            var details = await detailsDb.GrantDetails.ToListAsync();
            return Ok(details);

        }

        [HttpPost]

        public async Task<IActionResult> AddDetails(GrantDetail grantDetailRequest)
        {
          //  grantDetailRequest.Id = Guid.NewGuid();
            await detailsDb.GrantDetails.AddAsync(grantDetailRequest);
            await detailsDb.SaveChangesAsync();

            return Ok(grantDetailRequest);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetDetail([FromRoute] int id)
        {
            var detail = await detailsDb.GrantDetails.FirstOrDefaultAsync(x => x.Id==id);

            if (detail==null)
            {
                return NotFound();

            }
            return Ok(detail);
        }

        [HttpPut("{id}")]     

        public async Task<IActionResult> UpdateDetail(int id, GrantDetail updateGrantRequest)
        {
            var detail = await detailsDb.GrantDetails.FirstOrDefaultAsync(x => x.Id==id);
            
            if (detail == null)
            {
                return NotFound();
            }
            detail.GrantName = updateGrantRequest.GrantName;
            detail.ProgramCode = updateGrantRequest.ProgramCode;
            detail.StartDate = updateGrantRequest.StartDate;
            detail.EndDate = updateGrantRequest.EndDate;



            await detailsDb.SaveChangesAsync();

            return Ok(detail);


        }
        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteDetail([FromRoute] int id)

        {
            var detail = await detailsDb.GrantDetails.FindAsync(id);
            if (detail==null)
            {
                return NotFound();
            }
            detailsDb.GrantDetails.Remove(detail);
            await detailsDb.SaveChangesAsync();

            return Ok(detail);

        }

    }
}
