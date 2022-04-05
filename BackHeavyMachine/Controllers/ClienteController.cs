using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackHeavyMachine.Models.Repuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackHeavyMachine.Models;

namespace BackHeavyMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult VerClientes()
        {
            Respuesta Resp = new Respuesta();
           try
            {
               using (HeavyMachineContext db = new HeavyMachineContext())
                {
                    var lst = (from d in db.TCliente
                               select d).ToList();
                    if (lst.Count > 0)
                    {
                        Resp.exito = 1;
                        Resp.data = lst;
                        Resp.mensajes = "Exito";
                    }
                }
               
            }
            catch (Exception ex)
            {
                Resp.exito = 0;
                Resp.mensajes = ex.Message;
            }

            return Ok(Resp);
        }
    }
}
