using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure
{
    public class SrvMarca : IMarca
    {
        private readonly AutomotrizContext _context;

        public SrvMarca(AutomotrizContext contexto)
        {
            _context = contexto;
        }

        public async Task<Response<List<Marca>>> CargaInicial()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\CargaInicial\Marca.csv"));
            List<Marca> marcaList = new List<Marca>();
            while (!reader.EndOfStream)
            {
                Marca marca = new Marca();
                var line = reader.ReadLine();
                var values = line.Split(';');
                marca.MarNombre = values[1].ToString().Trim();
                if (marcaList.Find(x => x.MarNombre == marca.MarNombre) == null)
                    marcaList.Add(marca);
            }
            Response<List<Marca>> response = new Response<List<Marca>>();
            try
            {
                await _context.Marcas.AddRangeAsync(marcaList);
                await _context.SaveChangesAsync();
                response.Data = null;
                response.Message = "OK.";
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return await Consultar();
        }

        public async Task<Response<List<Marca>>> Consultar()
        {
            Response<List<Marca>> response = new Response<List<Marca>>();
            try
            {
                var result = await _context.Marcas
                    .ToListAsync();

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
