using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure
{
    public class SrvEjecutivo : IEjecutivo
    {
        private readonly AutomotrizContext _context;

        public SrvEjecutivo(AutomotrizContext contexto)
        {
            _context = contexto;
        }
        public async Task<Response<List<Ejecutivo>>> CargaInicial()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\CargaInicial\Ejecutivo.csv"));
            List<Ejecutivo> ejecutivoList = new List<Ejecutivo>();
            while (!reader.EndOfStream)
            {
                Ejecutivo ejecutivo = new Ejecutivo();
                var line = reader.ReadLine();
                var values = line.Split(';');
                ejecutivo.PatIdPatio = Convert.ToInt32(values[0]);
                ejecutivo.EjeIdentificacion = values[1].ToString();
                ejecutivo.EjeNombres = values[2].ToString();
                ejecutivo.EjeApellidos = values[3].ToString();
                ejecutivo.EjeDireccion = values[4].ToString();
                ejecutivo.EjeTelefonoConvencional = values[5].ToString();
                ejecutivo.EjeCelular = values[6].ToString();
                ejecutivo.EjeEdad = Convert.ToInt32(values[7]);

                if (ejecutivoList.Find(x => x.EjeIdentificacion == ejecutivo.EjeIdentificacion) == null)
                    ejecutivoList.Add(ejecutivo);
            }

            Response<List<Ejecutivo>> response = new Response<List<Ejecutivo>>();

            try
            {
                await _context.Ejecutivos.AddRangeAsync(ejecutivoList);
                await _context.SaveChangesAsync();
                response.Data = null;
                response.Message = "OK.";
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
                return response;
            }
            return await Consultar();
        }

        public async Task<Response<List<Ejecutivo>>> Consultar()
        {
            Response<List<Ejecutivo>> response = new Response<List<Ejecutivo>>();
            try
            {
                var result = await _context.Ejecutivos.ToListAsync();

                if (result != null)
                {
                    response.Data = result;
                    response.Message = "Ok.";
                }
                else
                {
                    response.Success = !response.Success;
                    response.Message = "Error";
                }
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<Ejecutivo>>> Consultar(int patio)
        {
            Response<List<Ejecutivo>> response = new Response<List<Ejecutivo>>();
            try
            {
                var result = await _context.Ejecutivos.Where(x => x.PatIdPatio == patio).ToListAsync();

                if (result != null)
                {
                    response.Data = result;
                    response.Message = "Ok.";
                }
                else
                {
                    response.Success = !response.Success;
                    response.Message = "Error";
                }
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return response;
        }
    }
}
