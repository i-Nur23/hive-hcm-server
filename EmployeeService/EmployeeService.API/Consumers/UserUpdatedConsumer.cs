﻿using Core.Events;
using Core.Exceptions;
using Core.Responses;
using EmployeeService.Application.Interfaces;
using MassTransit;
using System.Net;

namespace EmployeeService.API.Consumers
{
    public class UserUpdatedConsumer : IConsumer<UserUpdatedEvent>
    {
        private readonly IEmployeesService _employeesService;

        public UserUpdatedConsumer(
            IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        public async Task Consume(ConsumeContext<UserUpdatedEvent> context)
        {
            try
            {
                await _employeesService.UpdateAsync(context.Message);

                await context.RespondAsync<RequestResult>(new
                {
                    Ok = true
                });
            }
            catch (CustomResponseException exception)
            {
                await context.RespondAsync<RequestResult>(new
                {
                    Message = exception.Message,
                    Ok = false,
                    StatusCode = exception.StatusCode
                });
            }
            catch (Exception)
            {
                await context.RespondAsync<RequestResult>(new
                {
                    Message = "Ошибка сервера. Попробуйте позже.",
                    Ok = false,
                    StatusCode = HttpStatusCode.InternalServerError
                });
            }
        }
    }
}
