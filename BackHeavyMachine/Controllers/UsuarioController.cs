using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackHeavyMachine.Models.Vistas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackHeavyMachine.Models;
using BackHeavyMachine.Models.Repuestas;

namespace BackHeavyMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] UserView model)
        {
            Respuesta resp = new Respuesta();
            using (HeavyMachineContext db = new HeavyMachineContext())
            {
                RespLog oresp = new RespLog();
                var Ouser = new TUsuarios();
                Ouser = (from d in db.TUsuarios
                         where d.Usuario == model.usuario && d.Password == model.password
                         select d).FirstOrDefault();
                if (Ouser == null)
                {
                    return null;
                }
                resp.exito = 1;
                resp.mensajes = "exito";
                oresp.usuario = Ouser.Usuario;
                resp.data = oresp;

            }
            return Ok(resp);
        }
    }
}
