using System;
using Chelle.Application;
using Microsoft.AspNetCore.Mvc;

namespace Chelle.API.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? new OkObjectResult(result.Data)
            : new BadRequestObjectResult(new { errors = result.Errors });
    }
}
