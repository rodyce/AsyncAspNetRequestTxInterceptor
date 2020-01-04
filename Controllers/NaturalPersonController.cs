using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using AsyncAspNetRequestTxInterceptor.Entities;

[ApiController]
[Route("api/naturalperson")]
[Produces(MediaTypeNames.Application.Json)]
public class NaturalPersonController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly NaturalPersonRepository _naturalPersonRepository;

    public NaturalPersonController(IUnitOfWork unitOfWork, NaturalPersonRepository naturalPersonRepository)
    {
        _unitOfWork = unitOfWork;
        _naturalPersonRepository = naturalPersonRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NaturalPerson>>> Get()
    {
        var persons = await _naturalPersonRepository.LoadEntityList();
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NaturalPerson>> Get(long id)
    {
        var person = await _naturalPersonRepository.LoadEntityById(id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPut]
    public async Task<ActionResult<NaturalPerson>> Put(NaturalPerson person)
    {
        if (await _naturalPersonRepository.LoadEntityById(person.ID) != null)
        {
            return Conflict("Already exists");
        }
        await _unitOfWork.Save(person);
        var resourceUrl = $"{Request.Path.ToString()}/{Uri.EscapeUriString(person.ID.ToString())}";
        return Created(resourceUrl, person);
    }
}
