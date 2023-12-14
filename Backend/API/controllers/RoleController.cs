using API.controllers;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers;
public class RoleController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RoleController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RoleDto>>> Get()
    {
        var result = await _unitOfWork.Roles.GetAllAsync();
        return _mapper.Map<List<RoleDto>>(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoleDto>> Get(int id)
    {
        var result = await _unitOfWork.Roles.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return _mapper.Map<RoleDto>(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RoleDto>> Post([FromBody] RoleDto RoleDto)
    {
        var result = _mapper.Map<Role>(RoleDto);
        _unitOfWork.Roles.Add(result);
        await _unitOfWork.SaveAsync();
        if (result == null)
            return BadRequest();
        RoleDto.Id = result.Id;
        return CreatedAtAction(nameof(Post), new { Id = RoleDto.Id }, RoleDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoleDto>> Put(int id, [FromBody] RoleDto RoleDto)
    {
        if (RoleDto == null)
            return BadRequest();
        if (RoleDto.Id == 0)
            RoleDto.Id = id;
        if (RoleDto.Id != id)
            return NotFound();
        var result = _mapper.Map<Role>(RoleDto);
        _unitOfWork.Roles.Update(result);
        await _unitOfWork.SaveAsync();
        return RoleDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Roles.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        _unitOfWork.Roles.Remove(result);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}