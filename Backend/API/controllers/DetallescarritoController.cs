using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class DetallescarritoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetallescarritoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetallescarritoDto>>> Get()
    {
        var result = await _unitOfWork.DetallesCarritos.GetAllAsync();
        return _mapper.Map<List<DetallescarritoDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallescarritoDto>> Get(int id)
    {
        var result = await _unitOfWork.DetallesCarritos.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<DetallescarritoDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallescarritoDto>> Post([FromBody] DetallescarritoDto DetallescarritoDto)
    {
        var result = _mapper.Map<Detallescarrito>(DetallescarritoDto);
        _unitOfWork.DetallesCarritos.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        DetallescarritoDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = DetallescarritoDto.Id }, DetallescarritoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallescarritoDto>> Put(int id, [FromBody] DetallescarritoDto DetallescarritoDto)
    {
        if (DetallescarritoDto == null)
            return BadRequest();
        if (DetallescarritoDto.Id == 0)
            DetallescarritoDto.Id = id;
        if (DetallescarritoDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Detallescarrito>(DetallescarritoDto);
        _unitOfWork.DetallesCarritos.Update(result);
        await _unitOfWork.SaveAsync();
        return DetallescarritoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.DetallesCarritos.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.DetallesCarritos.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}