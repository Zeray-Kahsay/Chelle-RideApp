using System;
using Chelle.Application;
using Chelle.Core.Common;
using Microsoft.AspNetCore.Mvc;

namespace Chelle.API.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionBadRequestResult<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? new OkObjectResult(result.Data)
            : new BadRequestObjectResult(new { errors = result.Errors });
    }

    public static IActionResult ToActionNotFoundResult<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? new OkObjectResult(result.Data)
            : new NotFoundObjectResult(new { errors = result.Errors });
    }

    public static IActionResult ToActionUnAuthorizedResult<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? new OkObjectResult(result.Data)
            : new UnauthorizedObjectResult(new { errors = result.Errors });
    }
}
