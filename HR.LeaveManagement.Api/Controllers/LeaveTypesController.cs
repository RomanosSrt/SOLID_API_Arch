﻿using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            this._mediator = mediator; 
        }


        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<List<LeaveTypeDto>> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());


            return leaveTypes;
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<LeaveTypeDetailsDto> Get(int id)
        {
            var leaveTypeId = await _mediator.Send(new GetLeaveTypeDetailsQuery(id));

            return leaveTypeId;
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task Post([FromBody] string name, int days)
        {
            var leaveTypeAdd = await _mediator.Send(new CreateLeaveTypeCommand()
            {
                Name = name,
                DefaultDays = days
            });
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name, int days)
        {

        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}