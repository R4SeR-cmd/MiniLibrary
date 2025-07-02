namespace MiniLibrary.Middleware
{
    public class CustomJwtMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomJwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(authHeader) && !authHeader.StartsWith("Bearer "))
            {
                context.Request.Headers["Authorization"] = "Bearer " + authHeader;
            }
             
            await _next(context);
        }
    }

}
