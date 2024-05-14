using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Infra
{
	internal sealed class GlobalExceptionHandler : IExceptionHandler
	{
		private readonly ILogger<GlobalExceptionHandler> _logger;

		public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
		{
			_logger = logger;
		}

		public async ValueTask<bool> TryHandleAsync(
			HttpContext httpContext,
			Exception exception,
			CancellationToken cancellationToken)
		{
			var exceptionMessage = $"Exception occurred: {exception.Message}";

			_logger.LogError(
				exception, exceptionMessage);

			var problemDetails = new ProblemDetails
			{
				Status = StatusCodes.Status500InternalServerError,
				Title = "Server error",
				Detail = exceptionMessage
			};

			httpContext.Response.StatusCode = problemDetails.Status.Value;

			await httpContext.Response
				.WriteAsJsonAsync(problemDetails, cancellationToken);

			return true;
		}
	}
}