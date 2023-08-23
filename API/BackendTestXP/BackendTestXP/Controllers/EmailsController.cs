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
using BackendTestXP.Services;
using AutoMapper;
using BackendTestXP.Repository.Interfaces;

namespace BackendTestXP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailRepository _repository;
        private readonly IMapper _mapper;

        public EmailsController(IEmailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Emails
        [HttpGet]
        public async Task<IActionResult> GetEmails()
        {
            var emails = await _repository.GetEmails();

            var emailsRetorno = _mapper.Map<IEnumerable<EmailDTO>>(emails);

            return emailsRetorno.Any() ? Ok(emailsRetorno) : BadRequest("Emails não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmailsById(int id)
        {
            var email = await _repository.GetEmailById(id);

            var emailRetorno = _mapper.Map<EmailDTO>(email);

            return emailRetorno != null ? Ok(emailRetorno) : BadRequest("Email não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> PostEmail(EmailAdicionarDTO emailDto)
        {
            if (emailDto == null) return BadRequest("Dados inválidos");

            var mensagem = EmailService.VerificarEmail(emailDto.EnderecoEmail);

            if (mensagem != "ok") return BadRequest(mensagem);

            var emailAdd = _mapper.Map<Email>(emailDto);

            _repository.Add(emailAdd);

            return await _repository.SaveChanges() ? Ok(emailAdd) : BadRequest("Não foi possível adicionar o email");
        }

        [HttpPut]
        public async Task<IActionResult> PutEmail(int id, EmailAdicionarDTO emailDto)
        {
            if (id <= 0) return BadRequest("Email não encontrado");
            
            var email = await _repository.GetEmailById(id);

            var emailAtualizar = _mapper.Map(emailDto, email);

            _repository.Update(emailAtualizar);

            var mensagem = EmailService.VerificarEmail(emailDto.EnderecoEmail);

            if (mensagem != "ok") return BadRequest(mensagem);

            return await _repository.SaveChanges() ? Ok("Email atualizado!") : BadRequest("Não foi possível adicionar o email");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmail(int id)
        {
            if (id <= 0) return BadRequest("Usuário não encontrado");

            var emailExclui = await _repository.GetEmailById(id);

            if (emailExclui == null) return NotFound("Usuário não encontrado");

            _repository.Delete(emailExclui);

            return await _repository.SaveChanges() ? Ok("Cliente excluído")
                : BadRequest("Não foi possível excluir o cliente");
        }
    }
}
