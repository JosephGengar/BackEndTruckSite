using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackHeavyMachine.Models.Repuestas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackHeavyMachine.Models;
using BackHeavyMachine.Models.Vistas;

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
        [HttpPost]
        public IActionResult Agregar([FromBody] ClienteView modelo)
        {
            Respuesta oResp = new Respuesta();
            try
            {
                using (HeavyMachineContext db = new HeavyMachineContext())
                {
                    TCliente oCliente = new TCliente();
                    oCliente.Nombre = modelo.nombre;
                    oCliente.Telefono = modelo.telefono;
                    db.TCliente.Add(oCliente);
                    db.SaveChanges();
                    oResp.exito = 1;
                    oResp.mensajes = "exito";
                }
            }
            catch (Exception ex)
            {
                oResp.mensajes = ex.Message;
                oResp.exito = 0;
            }
            return Ok(oResp);
        }
        [HttpPut]
        public IActionResult Editar([FromBody] ClienteView modelo)
        {
            Respuesta oResp = new Respuesta();
            try
            {
                using (HeavyMachineContext db = new HeavyMachineContext())
                {
                    var oUser = db.TCliente.Find(modelo.id);
                    oUser.Nombre = modelo.nombre;
                    oUser.Telefono = modelo.telefono;
                    db.Entry(oUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oResp.exito = 1;
                    oResp.mensajes = "exito";
                }
            }
            catch (Exception ex)
            {

                oResp.mensajes = ex.Message;
                oResp.exito = 0;
            }
            return Ok(oResp);
        }
    }
}
