using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class DetallestransaccionController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DetallestransaccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetallestransaccionDto>>> Get()
    {
        var result = await _unitOfWork.DetallesTransaccions.GetAllAsync();
        return _mapper.Map<List<DetallestransaccionDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallestransaccionDto>> Get(int id)
    {
        var result = await _unitOfWork.DetallesTransaccions.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<DetallestransaccionDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallestransaccionDto>> Post([FromBody] DetallestransaccionDto DetallestransaccionDto)
    {
        var result = _mapper.Map<Detallestransaccion>(DetallestransaccionDto);
        _unitOfWork.DetallesTransaccions.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        DetallestransaccionDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = DetallestransaccionDto.Id }, DetallestransaccionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallestransaccionDto>> Put(int id, [FromBody] DetallestransaccionDto DetallestransaccionDto)
    {
        if (DetallestransaccionDto == null)
            return BadRequest();
        if (DetallestransaccionDto.Id == 0)
            DetallestransaccionDto.Id = id;
        if (DetallestransaccionDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Detallestransaccion>(DetallestransaccionDto);
        _unitOfWork.DetallesTransaccions.Update(result);
        await _unitOfWork.SaveAsync();
        return DetallestransaccionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.DetallesTransaccions.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.DetallesTransaccions.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}