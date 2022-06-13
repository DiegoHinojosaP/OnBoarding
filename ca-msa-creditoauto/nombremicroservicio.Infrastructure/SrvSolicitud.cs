using Mapster;
using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure
{
    public class SrvSolicitud : ISolicitud
    {
        private readonly AutomotrizContext _context;

        public SrvSolicitud(AutomotrizContext contexto)
        {
            _context = contexto;
        }

        public async Task<Response<string>> Agregar(Credito credito)
        {
            Response<string> response = new Response<string>();
            try
            {
                var sujetoCredito = await _context.Clientes.FirstOrDefaultAsync(x => x.CliIdCliente == credito.CliIdCliente && x.CliSujetoCredito == true);
                if (sujetoCredito != null)
                {
                    Vehiculo auto = await _context.Vehiculos.FirstOrDefaultAsync(x => x.VehIdVehiculo == credito.VehIdVehiculo && x.VehTipo == "S/R");
                    if (auto != null)
                    {
                        DateTime fecha = DateTime.Today;
                        List<Credito> Credito = await _context.Creditos.Where(x => x.CliIdCliente == credito.CliIdCliente && x.CreFechaElaboracion == fecha).ToListAsync();
                        if (Credito.Count == 0)
                        {
                            Asignacion asignacion = new Asignacion()
                            {
                                CliIdCliente = credito.CliIdCliente,
                                PatIdPatio = credito.PatIdPatio,
                                AsiFechaAsignacion = fecha
                            };
                            credito.CreFechaElaboracion = fecha;
                            auto.VehTipo = "Reservado";
                            await _context.Creditos.AddAsync(credito);
                            await _context.Asignacions.AddAsync(asignacion);
                            _context.Vehiculos.Update(auto);
                            await _context.SaveChangesAsync();
                            response.Data = null;
                            response.Message = "OK.";
                        }
                        else
                        {
                            response.Success = !response.Success;
                            response.Message = $"El Cliente ya tiene un credito con fecha {fecha}";
                        }
                    }
                    else
                    {
                        response.Success = !response.Success;
                        response.Message = $"El Vehiculo ya esta Reservado";
                    }
                }
                else
                {
                    response.Success = !response.Success;
                    response.Message = "El Cliente no es sujeto de Credito";
                }
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<DtoSolicitud>> Consultar(int id)
        {
            Response<DtoSolicitud> response = new Response<DtoSolicitud>();
            try
            {
                Credito credito = await _context.Creditos.FirstOrDefaultAsync(x => x.CreIdCredito == id);
                if (credito != null)
                {
                    Cliente cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.CliIdCliente == credito.CliIdCliente);
                    Patio patio = await _context.Patios.FirstOrDefaultAsync(x => x.PatIdPatio == credito.PatIdPatio);
                    Ejecutivo ejecutivo = await _context.Ejecutivos.FirstOrDefaultAsync(x => x.EjeIdEjecutivo == credito.EjeIdEjecutivo);
                    Vehiculo vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(x => x.VehIdVehiculo == credito.VehIdVehiculo);
                    Marca marca = await _context.Marcas.FirstOrDefaultAsync(x => x.MarIdMarca == vehiculo.MarIdMarca);
                    DtoSolicitud Reporte = new DtoSolicitud()
                    {
                        Patio = patio.PatNombre,
                        Ejecutivo = $"{ejecutivo.EjeNombres} {ejecutivo.EjeApellidos}",
                        Identificacion = cliente.CliIdentificacion,
                        Cliente = $"{cliente.CliNombres} {cliente.CliApellidos}",
                        FechaCrecion = credito.CreFechaElaboracion,
                        MesesPlazo = credito.CreMesesPlazo,
                        ValorCuota = credito.CreCuotas,
                        Entrada = credito.CreEntrada,
                        Estado = credito.CreEstado,
                        Vehiculo = {
                            VehPlaca = vehiculo.VehPlaca,
                            VehAvaluo = vehiculo.VehAvaluo,
                            VehCilindraje = vehiculo.VehCilindraje,
                            VehModelo = vehiculo.VehModelo,
                            VehNumeroChasis = vehiculo.VehNumeroChasis,
                            Marca = {Nombre = marca.MarNombre },
                        },
                    };
                    response.Data = Reporte;
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

        public async Task<Response<string>> Actualizar(Credito credito)
        {
            Response<string> response = new Response<string>();
            try
            {
                Credito result = await _context.Creditos.FirstOrDefaultAsync(x => x.CreIdCredito == credito.CreIdCredito && (x.CreEstado != "Despachada" || x.CreEstado != "Cancelada"));
                if (result != null)
                {
                    Vehiculo auto = await _context.Vehiculos.FirstOrDefaultAsync(x => x.VehIdVehiculo == credito.VehIdVehiculo && x.VehTipo == "Reservada");
                    if (auto != null)
                    {
                        switch (credito.CreEstado)
                        {
                            case "Despachada":
                                result.CreEstado = credito.CreEstado;
                                result.CreObservacion = credito.CreObservacion;
                                auto.VehTipo = "Despachada";
                                break;
                            case "Cancelada":
                                result.CreEstado = credito.CreEstado;
                                result.CreObservacion = credito.CreObservacion;
                                auto.VehTipo = "S/R";
                                break;
                            default:
                                break;
                        }
                        _context.Vehiculos.Update(auto);
                        _context.Creditos.Update(credito);
                        await _context.SaveChangesAsync();
                        response.Data = null;
                        response.Message = "Ok.";
                    }
                    else
                    {
                        response.Data = null;
                        response.Message = "Error auto no encontrado";
                        return response;
                    }
                }
                else
                {
                    response.Data = null;
                    response.Message = $"El credito se encuentra en procesado";
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
