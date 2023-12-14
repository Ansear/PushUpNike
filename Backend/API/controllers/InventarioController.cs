using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class InventarioController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InventarioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InventarioDto>>> Get()
    {
        var result = await _unitOfWork.Inventarios.GetAllAsync();
        return _mapper.Map<List<InventarioDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InventarioDto>> Get(int id)
    {
        var result = await _unitOfWork.Inventarios.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<InventarioDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InventarioDto>> Post([FromBody] InventarioDto InventarioDto)
    {
        var result = _mapper.Map<Inventario>(InventarioDto);
        _unitOfWork.Inventarios.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        InventarioDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = InventarioDto.Id }, InventarioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InventarioDto>> Put(int id, [FromBody] InventarioDto InventarioDto)
    {
        if (InventarioDto == null)
            return BadRequest();
        if (InventarioDto.Id == 0)
            InventarioDto.Id = id;
        if (InventarioDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Inventario>(InventarioDto);
        _unitOfWork.Inventarios.Update(result);
        await _unitOfWork.SaveAsync();
        return InventarioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Inventarios.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Inventarios.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}