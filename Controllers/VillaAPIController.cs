using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Rstfulapi.Logging;
using Rstfulapi.Models;

namespace Rstfulapi.Controllers
{
    [Route("api/[controller]")]
    //   [ApiController]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _Logger;
        private readonly Applicationdb _db;

        public VillaAPIController(ILogging logger, Applicationdb db)
        {
            _Logger = logger;
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Villa>> GetVillas()
        {
            _Logger.Log("Get All Villas", "");
            var villas = _db.villas.ToList();
            return Ok(villas);
        }


        [HttpGet("id", Name = "GetVillas")]
        public ActionResult<Villa> GetVillas(int id)
        {

            if (id == 0)
            {
                _Logger.Log("Get Villa With ID", "error");
                return BadRequest();
            }

            var villa = _db.villas.SingleOrDefault(u => u.id == id);
            if (villa == null)
            {
                return NotFound();
            }
            _Logger.Log("Get Villa With ID", "");
            return Ok(villa);
        }

        [HttpPost]
        public ActionResult<Villa> createVillas([FromBody] string villa)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(villa);
            }
            if (_db.villas.FirstOrDefault(u => u.Name.ToLower() == villa) != null)
            {
                ModelState.AddModelError("CustomOOOOmError", "يعم دخل اسم مش موجود بقا");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }
            Villa vobj = new()
            {
                Name = villa
            };
            _db.villas.Add(vobj);
            _db.SaveChanges();
            _Logger.Log("Create Villas", "");
            return Ok(vobj);
        //    return CreatedAtRoute("GetVilla", new { id = villa.id }, villa);

        }

        [HttpDelete("id")]
        public IActionResult DeleteVillas(int id)
        {
            
            if (id == 0)
            {
                return NoContent();
            }
            var villadeleted = _db.villas.SingleOrDefault(s => s.id == id);
            if (villadeleted == null)
            {
                ModelState.AddModelError("CustomOOOOmError", "مش موجود يبشه والله");
                return BadRequest(ModelState);
            }
            _db.villas.Remove(villadeleted);
            _db.SaveChanges();
            _Logger.Log("Delete Villas", "");
            ModelState.AddModelError("Message", "The delete operation Done");
            return BadRequest(ModelState);

        }

        [HttpPut("id")]
        public IActionResult UPdateVillas(int id, [FromBody] Villa villa)
        {
            
            if (!ModelState.IsValid || id != villa.id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid || id == 0)
            {
                return BadRequest();
            }

            //var villaupdate = _db.villas.FirstOrDefault(f => f.id == id);
            if (villa == null)
            {
                return NotFound("Villa not fount");
            }
            Villa model = new()
            {
                id = villa.id,
                Name = villa.Name
            };
            _db.villas.Update(model);
            _db.SaveChanges();
            _Logger.Log("Update Villas", "");
            return Ok(model);
        }

        [HttpPatch("{id:int}" ,Name = "UPdatePartualVillas")]
        public IActionResult UPdatePartualVillas(int id, JsonPatchDocument<Villa> patchvilla)
        {
           
            if (patchvilla == null || id == 0)
            {
                return BadRequest();
            }

            var villaupdate = _db.villas.AsNoTracking().FirstOrDefault(f => f.id == id);
            if (villaupdate == null)
            {
                return NotFound("Villa not fount");
            }
            Villa villa = new()
            {
                id = villaupdate.id,
                Name= villaupdate.Name
            };

          
            patchvilla.ApplyTo(villa, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa model = new Villa()
            {
                id = villa.id,
                Name = villa.Name,
            };
            _db.villas.Update(model);
            _db.SaveChanges();
            _Logger.Log("Patch Villas", "");
            return NoContent();
        }
    }
}
