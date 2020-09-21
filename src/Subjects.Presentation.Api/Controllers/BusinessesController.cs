﻿using GoodToCode.Extensions;
using GoodToCode.Extensions.Mvc;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodToCode.Subjects.Application
{
    [Produces("application/json", "application/xml")]
    [ApiExplorerSettings(GroupName = "BusinessSpecification")]
    [Route("/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class BusinessesController : ControllerMediator
    {
        private readonly SubjectsDbContext _dbContext;

        public BusinessesController(SubjectsDbContext context, IMediator mediator) : base(mediator)
        {
            _dbContext = context;
        }

        // GET: api/Businesses
        [HttpGet]
        [ProducesResponseType(typeof(List<Business>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusiness()
        {
            var query = new BusinessesGetQuery();
            var queryResponse = await Mediator.Send(query);

            if (queryResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);

            if (queryResponse.Result.Count == 0)
                return NotFound();

            return Ok(queryResponse.Result);
        }

        // GET: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpGet("{key}")]
        [ProducesResponseType(typeof(Business), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Business>> GetBusiness(Guid key)
        {
            var query = new BusinessGetQuery(key);
            var queryResponse = await Mediator.Send(query);

            if (queryResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);

            if (queryResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

            if (queryResponse.Result.BusinessKey == Guid.Empty)
                return NotFound();

            return Ok(queryResponse.Result);
        }

        // POST: api/Businesses/
        [HttpPost()]
        [ProducesResponseType(typeof(Business), 200)]
        [ProducesResponseType(typeof(Business), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Business>> PostBusiness([FromBody] Business item)
        {
            var command = new BusinessCreateCommand(item);
            var cmdResponse = await Mediator.Send(command);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            
            var getUrl = new Uri(Request.Path.ToString().AddLast("/").AddLast(cmdResponse.Result.BusinessKey.ToString()));

            return Created(getUrl, cmdResponse.Result);
        }

        // PUT: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpPut("{key}")]
        [ProducesResponseType(typeof(Business), 201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Business>> PutBusiness(Guid key, [FromBody] Business item)
        {

            if (key == Guid.Empty)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

            var command = new BusinessUpdateCommand(item);
            var cmdResponse = await Mediator.Send(command);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);

            return Ok(cmdResponse.Result);
        }

        // DELETE: api/Businesses/376B76B4-1EA8-4B31-9238-41E59784B5DD
        [HttpDelete("{key}")]
        public async Task<ActionResult> DeleteBusiness(Guid key)
        {
            var command = new BusinessDeleteCommand();
            var cmdResponse = await Mediator.Send(command);

            if (cmdResponse.Errors.Any())
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest, cmdResponse);

            if (cmdResponse.ErrorInfo.HasException)
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, cmdResponse);

            return new OkResult();
        }
    }
}