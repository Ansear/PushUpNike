using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class CategoriaController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
    {
        var result = await _unitOfWork.Categorias.GetAllAsync();
        return _mapper.Map<List<CategoriaDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> Get(int id)
    {
        var result = await _unitOfWork.Categorias.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<CategoriaDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Post([FromBody] CategoriaDto CategoriaDto)
    {
        var result = _mapper.Map<Categoria>(CategoriaDto);
        _unitOfWork.Categorias.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        CategoriaDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = CategoriaDto.Id }, CategoriaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> Put(int id, [FromBody] CategoriaDto CategoriaDto)
    {
        if (CategoriaDto == null)
            return BadRequest();
        if (CategoriaDto.Id == 0)
            CategoriaDto.Id = id;
        if (CategoriaDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Categoria>(CategoriaDto);
        _unitOfWork.Categorias.Update(result);
        await _unitOfWork.SaveAsync();
        return CategoriaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Categorias.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Categorias.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}