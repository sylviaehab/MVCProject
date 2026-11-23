using System.Diagnostics;

namespace MVCProject.MiddleWare
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimeMiddleware(RequestDelegate next)
        {
            _next= next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stop=Stopwatch.StartNew();
            await _next.Invoke(context);
            stop.Stop();
            Console.WriteLine($"Request time: {stop.ElapsedMilliseconds} ms");
        }
    }
}
