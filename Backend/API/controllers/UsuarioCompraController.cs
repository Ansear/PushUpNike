using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class UsuarioCompraController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UsuarioCompraController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<UsuarioComprasDto>>> Get()
    {
        var result = await _unitOfWork.UsuariosCompras.GetAllAsync();
        return _mapper.Map<List<UsuarioComprasDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioComprasDto>> Get(int id)
    {
        var result = await _unitOfWork.UsuariosCompras.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<UsuarioComprasDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UsuarioComprasDto>> Post([FromBody] UsuarioComprasDto UsuarioCompraDto)
    {
        var result = _mapper.Map<Usuarioscompra>(UsuarioCompraDto);
        _unitOfWork.UsuariosCompras.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        UsuarioCompraDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = UsuarioCompraDto.Id }, UsuarioCompraDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UsuarioComprasDto>> Put(int id, [FromBody] UsuarioComprasDto UsuarioCompraDto)
    {
        if (UsuarioCompraDto == null)
            return BadRequest();
        if (UsuarioCompraDto.Id == 0)
            UsuarioCompraDto.Id = id;
        if (UsuarioCompraDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Usuarioscompra>(UsuarioCompraDto);
        _unitOfWork.UsuariosCompras.Update(result);
        await _unitOfWork.SaveAsync();
        return UsuarioCompraDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.UsuariosCompras.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.UsuariosCompras.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}