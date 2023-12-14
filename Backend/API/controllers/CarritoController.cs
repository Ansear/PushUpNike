using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class CarritoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CarritoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CarritoDto>>> Get()
    {
        var result = await _unitOfWork.Carritos.GetAllAsync();
        return _mapper.Map<List<CarritoDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarritoDto>> Get(int id)
    {
        var result = await _unitOfWork.Carritos.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<CarritoDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CarritoDto>> Post([FromBody] CarritoDto CarritoDto)
    {
        var result = _mapper.Map<Carrito>(CarritoDto);
        _unitOfWork.Carritos.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        CarritoDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = CarritoDto.Id }, CarritoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CarritoDto>> Put(int id, [FromBody] CarritoDto CarritoDto)
    {
        if (CarritoDto == null)
            return BadRequest();
        if (CarritoDto.Id == 0)
            CarritoDto.Id = id;
        if (CarritoDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Carrito>(CarritoDto);
        _unitOfWork.Carritos.Update(result);
        await _unitOfWork.SaveAsync();
        return CarritoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Carritos.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Carritos.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}