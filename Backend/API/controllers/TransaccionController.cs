using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class TransaccionController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TransaccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TransaccionDto>>> Get()
    {
        var result = await _unitOfWork.Transacciones.GetAllAsync();
        return _mapper.Map<List<TransaccionDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TransaccionDto>> Get(int id)
    {
        var result = await _unitOfWork.Transacciones.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<TransaccionDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TransaccionDto>> Post([FromBody] TransaccionDto TransaccionDto)
    {
        var result = _mapper.Map<Transaccione>(TransaccionDto);
        _unitOfWork.Transacciones.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        TransaccionDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = TransaccionDto.Id }, TransaccionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TransaccionDto>> Put(int id, [FromBody] TransaccionDto TransaccionDto)
    {
        if (TransaccionDto == null)
            return BadRequest();
        if (TransaccionDto.Id == 0)
            TransaccionDto.Id = id;
        if (TransaccionDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Transaccione>(TransaccionDto);
        _unitOfWork.Transacciones.Update(result);
        await _unitOfWork.SaveAsync();
        return TransaccionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Transacciones.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Transacciones.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}