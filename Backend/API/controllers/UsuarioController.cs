using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class UsuarioController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsuarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
    {
        var result = await _unitOfWork.Usuarios.GetAllAsync();
        return _mapper.Map<List<UsuarioDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> Get(int id)
    {
        var result = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<UsuarioDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioDto UsuarioDto)
    {
        var result = _mapper.Map<Usuario>(UsuarioDto);
        _unitOfWork.Usuarios.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        UsuarioDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = UsuarioDto.Id }, UsuarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioDto>> Put(int id, [FromBody] UsuarioDto UsuarioDto)
    {
        if (UsuarioDto == null)
            return BadRequest();
        if (UsuarioDto.Id == 0)
            UsuarioDto.Id = id;
        if (UsuarioDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Usuario>(UsuarioDto);
        _unitOfWork.Usuarios.Update(result);
        await _unitOfWork.SaveAsync();
        return UsuarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Usuarios.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Usuarios.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}