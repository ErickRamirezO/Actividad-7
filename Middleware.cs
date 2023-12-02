public class CustomMiddleware {
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        // Registro de solicitud antes del procesamiento

        await _next(context);

        // Registro de solicitud después del procesamiento
    }
}
