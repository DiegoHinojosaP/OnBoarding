using Mapster;
using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure
{
    public class SrvPatio : IPatio
    {
        private readonly AutomotrizContext _context;

        public SrvPatio(AutomotrizContext contexto)
        {
            _context = contexto;
        }

        public async Task<Response<List<Patio>>> Consultar()
        {
            Response<List<Patio>> response = new Response<List<Patio>>();
            try
            {
                var result = await _context.Patios
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

        public async Task<Response<string>> Agregar(Patio patio)
        {
            Response<string> response = new Response<string>();
            try
            {
                var solicitud = await _context.Patios.FirstOrDefaultAsync(x => x.PatNombre == patio.PatNombre);
                if (solicitud == null)
                {
                    await _context.Patios.AddAsync(patio);
                    await _context.SaveChangesAsync();
                    response.Data = null;
                    response.Message = "OK.";
                }
                else
                {
                    response.Success = !response.Success;
                    response.Message = "El Patio ya se encuentra registrado";
                }
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<string>> Actualizar(DtoPatio patio)
        {
            Response<string> response = new Response<string>();
            try
            {
                Patio result = await _context.Patios.FirstOrDefaultAsync(x => x.PatNombre == patio.PatNombre);
                if (result != null)
                {
                    Patio customerUpdate = patio.Adapt(result);
                    _context.Patios.Update(customerUpdate);
                    await _context.SaveChangesAsync();
                    response.Data = null;
                    response.Message = "Ok.";
                }
                else
                {
                    response.Data = null;
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

        public async Task<Response<string>> Eliminar(int id)
        {
            Response<string> response = new Response<string>();
            try
            {
                var solicitud = await _context.Creditos.FirstOrDefaultAsync(x => x.PatIdPatio == id);

                if (solicitud == null)
                {
                    var result = await _context.Patios.FirstOrDefaultAsync(x => x.PatIdPatio == id);
                    if (result != null)
                    {
                        _context.Patios.Remove(result);
                        await _context.SaveChangesAsync();
                        response.Data = null;
                        response.Message = "Ok.";
                    }
                    else
                    {
                        response.Success = !response.Success;
                        response.Message = "Error";
                    }
                }
                else
                {
                    response.Success = !response.Success;
                    response.Message = "El patio tiene asociado creditos";
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
