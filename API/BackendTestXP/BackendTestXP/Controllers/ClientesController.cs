using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendTestXP.Model;
using XPTesteAPI.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;
using BackendTestXP.Services;
using BackendTestXP.DTOs;
using NuGet.Protocol.Core.Types;
using BackendTestXP.Repository.Interfaces;
using AutoMapper;

namespace BackendTestXP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClientesController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _repository.GetClientes();

            var clienteRetorno = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);

            return clienteRetorno.Any() ? Ok(clienteRetorno) : BadRequest("Clientes não encontrados");
        }

        [HttpGet("Detalhes")]
        public async Task<IActionResult> GetClientesDetalhes()
        {
            var clientes = await _repository.GetClientesDetalhes();

            var clienteRetorno = _mapper.Map<IEnumerable<ClienteDetalhesDTO>>(clientes);

            return clienteRetorno.Any() ? Ok(clientes) : BadRequest("Clientes não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _repository.GetClienteById(id);

            var clienteRetorno = _mapper.Map<ClienteDTO>(cliente);

            return clienteRetorno != null ? Ok(clienteRetorno) : BadRequest("Cliente não encontrado");
        }

        [HttpGet("Detalhes/{id}")]
        public async Task<IActionResult> GetClientesDetalhesById(int id)
        {
            var cliente = await _repository.GetClientesDetalhesById(id);

            var clienteRetorno = _mapper.Map<ClienteDetalhesDTO>(cliente);

            return clienteRetorno != null ? Ok(clienteRetorno) : BadRequest("Cliente não encontrado");
        }


        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteAdicionarDTO clienteDTO)
        {
            
            if (clienteDTO == null) return BadRequest("Dados Inválidos");

            var mensagem = ClienteService.VerificarCliente(clienteDTO.Telefone);

            if (mensagem != "ok") return BadRequest(mensagem);

            var clienteAdd = _mapper.Map<Cliente>(clienteDTO);

            _repository.Add(clienteAdd);

            return await _repository.SaveChanges() ? Ok(clienteAdd) : BadRequest("Não foi possível salvar");
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(int id, ClienteAdicionarDTO clienteDto)
        {
            if (id <= 0) return BadRequest("Usuário não encontrado");

            var mensagem = ClienteService.VerificarCliente(clienteDto.Telefone);

            if (mensagem != "ok") return BadRequest(mensagem);

            var cliente = await _repository.GetClienteById(id);

            var clienteAtualizar = _mapper.Map(clienteDto, cliente);

            _repository.Update(clienteAtualizar);

            return await _repository.SaveChanges() ? Ok("Cliente atualizado") 
                : BadRequest("Não foi possível atualizar o cliente");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (id <= 0) return BadRequest("Usuário não encontrado");

            var clienteExclui = await _repository.GetClienteById(id);

            if(clienteExclui == null) return NotFound("Usuário não encontrado");

            _repository.Delete(clienteExclui);

            return await _repository.SaveChanges() ? Ok("Cliente excluído")
                : BadRequest("Não foi possível excluir o cliente");
        }
    }
}
