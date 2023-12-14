using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class DetallespedidoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetallespedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetallespedidoDto>>> Get()
    {
        var result = await _unitOfWork.DetallesPedidos.GetAllAsync();
        return _mapper.Map<List<DetallespedidoDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallespedidoDto>> Get(int id)
    {
        var result = await _unitOfWork.DetallesPedidos.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<DetallespedidoDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallespedidoDto>> Post([FromBody] DetallespedidoDto DetallespedidoDto)
    {
        var result = _mapper.Map<Detallespedido>(DetallespedidoDto);
        _unitOfWork.DetallesPedidos.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        DetallespedidoDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = DetallespedidoDto.Id }, DetallespedidoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallespedidoDto>> Put(int id, [FromBody] DetallespedidoDto DetallespedidoDto)
    {
        if (DetallespedidoDto == null)
            return BadRequest();
        if (DetallespedidoDto.Id == 0)
            DetallespedidoDto.Id = id;
        if (DetallespedidoDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Detallespedido>(DetallespedidoDto);
        _unitOfWork.DetallesPedidos.Update(result);
        await _unitOfWork.SaveAsync();
        return DetallespedidoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.DetallesPedidos.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.DetallesPedidos.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}