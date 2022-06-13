using Mapster;
using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure
{
    public class SrvAuto : IAuto
    {
        private readonly AutomotrizContext _context;
        public SrvAuto(AutomotrizContext contexto)
        {
            _context = contexto;
        }

        public async Task<Response<List<Vehiculo>>> Consultar()
        {

            Response<List<Vehiculo>> response = new Response<List<Vehiculo>>();
            try
            {
                var result = await _context.Vehiculos.ToListAsync();

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

        public async Task<Response<string>> Agregar(Vehiculo vehiculo)
        {
            Response<string> response = new Response<string>();
            try
            {
                Vehiculo result = await _context.Vehiculos.FirstOrDefaultAsync(x => x.VehPlaca == vehiculo.VehPlaca);
                if (result == null)
                {
                    await _context.Vehiculos.AddAsync(vehiculo);
                    await _context.SaveChangesAsync();
                    response.Data = null;
                    response.Message = "OK.";
                }
                else
                {
                    response.Data = null;
                    response.Message = $"El Vehiculo de Placa {vehiculo.VehPlaca} ya existe";
                }
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<string>> Actualizar(DtoVehiculo vehiculo)
        {
            Response<string> response = new Response<string>();
            try
            {
                Vehiculo result = await _context.Vehiculos.FirstOrDefaultAsync(x => x.VehPlaca == vehiculo.VehPlaca);
                if (result != null)
                {
                    Vehiculo customerUpdate = vehiculo.Adapt(result);
                    _context.Vehiculos.Update(customerUpdate);
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
                var solicitud = await _context.Creditos.FirstOrDefaultAsync(x => x.VehIdVehiculo == id );
                if (solicitud == null)
                {
                    var result = await _context.Vehiculos.FirstOrDefaultAsync(x => x.VehIdVehiculo == id);
                    if (result != null)
                    {
                        _context.Vehiculos.Remove(result);
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
                    response.Message = "El vehiculo tiene asociado un credito";
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
