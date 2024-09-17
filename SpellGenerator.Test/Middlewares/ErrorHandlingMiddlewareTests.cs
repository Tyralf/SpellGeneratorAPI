using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using SpellGenerator.API.Middlewares.ErrorHandling;

namespace SpellGenerator.Test.Middlewares
{

    public class ErrorHandlingMiddlewareTests
    {
        [Fact]
        public async Task Should_Handle_Generic_Exception_With_InternalServerErrorStrategy()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var envMock = new Mock<IWebHostEnvironment>();
            var middleware = new ErrorHandlingMiddleware(
                next: (innerHttpContext) => throw new Exception("Test exception"),
                logger: loggerMock.Object,
                env: envMock.Object);

            var context = new DefaultHttpContext();

            // Act
            await middleware.Invoke(context);

            // Assert
            // Assuming InternalServerErrorStrategy sets status code to 500
            Assert.Equal(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
        }

        [Fact]
        public async Task Should_Handle_KeyNotFoundException_With_NotFoundErrorStrategy()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<ErrorHandlingMiddleware>>();
            var envMock = new Mock<IWebHostEnvironment>();
            var middleware = new ErrorHandlingMiddleware(
                next: (innerHttpContext) => throw new KeyNotFoundException("Key not found"),
                logger: loggerMock.Object,
                env: envMock.Object);

            var context = new DefaultHttpContext();

            // Act
            await middleware.Invoke(context);

            // Assert
            // Assuming NotFoundErrorStrategy sets status code to 404
            Assert.Equal(StatusCodes.Status404NotFound, context.Response.StatusCode);
        }
    }
}
