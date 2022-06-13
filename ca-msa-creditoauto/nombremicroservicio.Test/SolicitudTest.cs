using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nombremicroservicio.API.Controllers;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using nombremicroservicio.Infrastructure;
using nombremicroservicio.Test.Conection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Test
{
    [TestClass]
    public class SolicitudTest : AutomotrizTest
    {

        [TestMethod]
        public async Task SujetoCreditoTrue()
        {
            string baseDatos = Guid.NewGuid().ToString();
            var context = ConecciontContext(baseDatos);

            Credito credito = new Credito()
            {
                CliIdCliente = 1,
                EjeIdEjecutivo = 1,
                VehIdVehiculo = 1,
                PatIdPatio = 1,
                CreMesesPlazo = 24,
                CreCuotas = 416,
                CreEntrada = 10000,
                CreEstado = "Despachada",
                CreObservacion = "Entrega de cuota entrada"
            };

            ISolicitud _solicitud = new SrvSolicitud(context);
            dynamic result = await _solicitud.Agregar(credito);
            Assert.AreEqual("OK.", result.Message);
        }

        [TestMethod]
        public async Task SujetoCreditoFalse()
        {
            string baseDatos = Guid.NewGuid().ToString();
            var context = ConecciontContext(baseDatos);

            Credito credito = new Credito()
            {
                CliIdCliente = 2,
                EjeIdEjecutivo = 1,
                VehIdVehiculo = 1,
                PatIdPatio = 1,
                CreMesesPlazo = 24,
                CreCuotas = 416,
                CreEntrada = 10000,
                CreEstado = "Despachada",
                CreObservacion = "Entrega de cuota entrada"
            };

            ISolicitud _solicitud = new SrvSolicitud(context);
            dynamic result = await _solicitud.Agregar(credito);
            Assert.AreEqual("El Cliente no es sujeto de Credito", result.Message);
        }

    }
}
