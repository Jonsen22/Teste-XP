using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendTestXP.Model;
using XPTesteAPI.Entities;
using BackendTestXP.DTOs;
using AutoMapper;
using BackendTestXP.Repository.Interfaces;
using BackendTestXP.Services;

namespace BackendTestXP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoesController : ControllerBase
    {
        private readonly IEnderecoRepository _repository;
        private readonly IMapper _mapper;

        public EnderecoesController(IEnderecoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Enderecoes
        [HttpGet]
       public async Task<IActionResult> GetEnderecos()
        {
            var enderecos = await _repository.GetEnderecos();

            var enderecoRetorno = _mapper.Map<IEnumerable<EnderecoDTO>>(enderecos);

            return enderecoRetorno.Any() ? Ok(enderecoRetorno) : BadRequest("Endereços não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnderecoById(int id)
        {
            var Endereco = await _repository.GetEnderecoById(id);

            var enderecoRetorno = _mapper.Map<EnderecoDTO>(Endereco);

            return enderecoRetorno != null ? Ok(enderecoRetorno) : BadRequest("Endereço não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> PostEndereco(EnderecoAdicionarDTO enderecoDTO)
        {

            if (enderecoDTO == null) return BadRequest("Dados Inválidos");

            var enderecoAdd = _mapper.Map<Endereco>(enderecoDTO);

            _repository.Add(enderecoAdd);

            return await _repository.SaveChanges() ? Ok(enderecoAdd) : BadRequest("Não foi possível salvar");
        }

        [HttpPut]
        public async Task<IActionResult> PutEndereco(int id, EnderecoAdicionarDTO enderecoDto)
        {
            if (id <= 0) return BadRequest("Endereço não encontrado");

            var endereco = await _repository.GetEnderecoById(id);

            var enderecoAtualizar = _mapper.Map(enderecoDto, endereco);

            _repository.Update(enderecoAtualizar);

            return await _repository.SaveChanges() ? Ok("Endereço atualizado")
                : BadRequest("Não foi possível atualizar o endereço");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (id <= 0) return BadRequest("Endereço não encontrado");

            var enderecoExclui = await _repository.GetEnderecoById(id);

            if (enderecoExclui == null) return NotFound("Usuário não encontrado");

            _repository.Delete(enderecoExclui);

            return await _repository.SaveChanges() ? Ok("Endereço excluído")
                : BadRequest("Não foi possível excluir o endereço");
        }
    }
}
