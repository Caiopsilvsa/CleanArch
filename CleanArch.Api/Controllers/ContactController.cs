using CleanArch.Application.Repositories;
using CleanArch.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

[ApiController]
[Route("V1/Contacts")]
public class ContactController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ContactController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route("GetAll")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Contact>))]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var contacts = await _unitOfWork.ContactRepository.GetAllAsync();

            if (contacts == null)
                throw new Exception("Erro durante a operação");

            return Ok(contacts);

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    [HttpGet()]
    [Route("GetById")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GetById(int contactId)
    {
        try
        {
            if (contactId == null)
                return BadRequest("Id do contato necessário");

            return Ok(await _unitOfWork.ContactRepository.GetByIdAsync(contactId));
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    [HttpPost]
    [Route("Insert")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]

    public async Task<IActionResult> Insert([FromBody] Contact contact)
    {
        try
        {
            if (contact == null)
                throw new Exception("Contato obrigatório");

           

            await _unitOfWork.ContactRepository.AddAsync(contact);

            return Ok();

        }

        catch (Exception ex)
        {

            throw ex;
        }
    }

    [HttpDelete()]
    [Route("Delete")]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(int contactId)
    {
        try
        {
            if (contactId == null)
                return BadRequest("Id do contato necessário");

            await _unitOfWork.ContactRepository.DeleteAsync(contactId);

            return Ok("Deletado com sucesso");
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }


    [HttpPut()]
    [Route("Update")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Update(Contact contact)
    {
        try
        {
            if (contact == null)
                return BadRequest("Contato necessário");

            var oldContact = _unitOfWork.ContactRepository.GetByIdAsync(contact.ContactID);
            
            if (oldContact == null) return BadRequest("Contato inexistente");

            await _unitOfWork.ContactRepository.UpdateAsync(contact);

            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}
