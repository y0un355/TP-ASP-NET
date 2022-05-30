using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TPASPnet5.data;
using TPASPnet5.Models;

namespace TPASPnet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class commandController : ControllerBase
    {
        private TP_APIDbContext _DbContext;
        public commandController(TP_APIDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        
        [HttpGet("GetCmds")]
        public IActionResult Get()
        {
            
            var Commande = _DbContext.infoCommande.ToList();

            if (Commande.Count == 0)
            {
                return StatusCode(404, "y'a aucune commande");
            }

            return Ok(Commande);

        }


        [HttpPost("AddCmd")]
        
        public IActionResult Add([FromBody] commandRequest request)
        {

            Commande cmd = new Commande();
            cmd.IdCmd = request.IdCmd;
            cmd.nomClient = request.nomClient;
            cmd.cEntree = request.cEntree;
            cmd.cPlat = request.cPlat;
            cmd.cDessert = request.cDessert;
            cmd.cBoisson = request.cBoisson;
            cmd.cSituation = request.cSituation;
            _DbContext.infoCommande.Add(cmd);
            _DbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateCmd")]
        public IActionResult Update([FromBody] commandRequest request)
        {
            var cmd = _DbContext.infoCommande.FirstOrDefault(i => i.IdCmd == request.IdCmd);
            if (cmd == null)
            {
                return StatusCode(404, "y'a aucune commande");
            }

            cmd.IdCmd = request.IdCmd;
            cmd.nomClient = request.nomClient;
            cmd.cEntree = request.cEntree;
            cmd.cPlat = request.cPlat;
            cmd.cDessert = request.cDessert;
            cmd.cBoisson = request.cBoisson;
            cmd.cSituation = request.cSituation;

            _DbContext.Entry(cmd).State = EntityState.Modified;
            _DbContext.SaveChanges();

            var cmds = Get();
            return Ok(cmds);
        }

       
        [HttpDelete("DeleteCmd/{Id}")]
        public IActionResult Delete([FromRoute] string Id)
        {

            var cmd = _DbContext.infoCommande.FirstOrDefault(i => i.IdCmd==Id);
            if (cmd == null)
            {
                return StatusCode(404, "y'a aucune commande");
            }

            _DbContext.Entry(cmd).State = EntityState.Deleted;
            _DbContext.SaveChanges();
            return Ok();
        }

       
    }
}
