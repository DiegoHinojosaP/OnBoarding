using Mapster;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Entities.Dto;
using nombremicroservicio.Entities.Respuesta;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure
{
    public class SrvCliente : ICliente
    {
        private readonly AutomotrizContext _context;

        public SrvCliente(AutomotrizContext contexto)
        {
            _context = contexto;
        }

        public async Task<Response<List<Cliente>>> CargaInicial()
        {
            var reader = new StreamReader(File.OpenRead(@"C:\CargaInicial\Clientes.csv"));
            List<Cliente> clienteList = new List<Cliente>();
            while (!reader.EndOfStream)
            {
                Cliente cliente = new Cliente();
                var line = reader.ReadLine();
                var values = line.Split(';');
                cliente.CliIdentificacion = values[0].ToString();
                cliente.CliNombres = values[1].ToString().Trim();
                cliente.CliApellidos = values[2].ToString().Trim();
                cliente.CliEdad = Convert.ToInt32(values[3]);
                cliente.CliFechaNacimiento = Convert.ToDateTime(values[4]);
                cliente.CliDireccion = values[5].ToString().Trim();
                cliente.CliTelefono = values[6].ToString();
                cliente.CliEstadoCivil = values[7].ToString();
                cliente.CliIdentificacionConyugue = values[8].ToString();
                cliente.CliNombreConyugue = values[9].ToString();
                cliente.CliSujetoCredito = Convert.ToBoolean(Convert.ToInt32(values[10]));

                if (clienteList.Find(x => x.CliIdentificacion == cliente.CliIdentificacion) == null)
                    clienteList.Add(cliente);
            }

            Response<List<Cliente>> response = new Response<List<Cliente>>();                
                try
                {
                    await _context.Clientes.AddRangeAsync(clienteList);
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

        public async Task<Response<List<Cliente>>> Consultar() {

            Response<List<Cliente>> response = new Response<List<Cliente>>();
            try
            {
                var result = await _context.Clientes
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

        public async Task<Response<DtoCliente>> Consultar(int id)
        {
            Response<DtoCliente> response = new Response<DtoCliente>();
            try
            {
                var result = await _context.Clientes.FirstOrDefaultAsync(x => x.CliIdCliente == id);
                if (result != null)
                {
                    response.Data = result.Adapt<DtoCliente>();
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

        public async Task<Response<string>> Agregar(Cliente cliente)
        {
            Response<string> response = new Response<string>();
            try
            {
                var solicitud = await _context.Clientes.FirstOrDefaultAsync(x => x.CliIdentificacion == cliente.CliIdentificacion);
                if (solicitud == null)
                {
                    await _context.Clientes.AddAsync(cliente);
                    await _context.SaveChangesAsync();
                    response.Data = null;
                    response.Message = "OK.";
                }
                else
                {
                    response.Success = !response.Success;
                    response.Message = "El cliente ya se encuentra registrado";
                }
            }
            catch (Exception e)
            {
                response.Success = !response.Success;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<string>> Actualizar(DtoCliente cliente)
        {
            Response<string> response = new Response<string>();
            try
            {
                Cliente result = await _context.Clientes.FirstOrDefaultAsync(x => x.CliIdentificacion == cliente.CliIdentificacion);
                if (result != null)
                {
                    Cliente customerUpdate = cliente.Adapt(result);
                    _context.Clientes.Update(customerUpdate);
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
                var solicitud = await _context.Creditos.FirstOrDefaultAsync(x => x.CliIdCliente == id);
                if (solicitud == null)
                {
                    var result = await _context.Clientes.FirstOrDefaultAsync(x => x.CliIdCliente == id);
                    if (result != null)
                    {
                        _context.Clientes.Remove(result);
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
                    response.Message = "El cliente tiene asociado un credito";
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
