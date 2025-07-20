using EventFlow.Application.DTOs.Events;
using EventFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventFlow.Application.DTOs.Users
{
    public record UserDto(
        Guid Id,
        string UserName,
        string Email,
        DateTime CreatedDate,
        DateTime UpdatedDate,
        List<string> Roles,
        List<EventDto> OrganizedEvents
    );
}
