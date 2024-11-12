namespace EGM.AracKiralama.API.MiddleWares
{
    public class FirstMiddleWare
    {
        private RequestDelegate _next;
        public FirstMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("1. middleware çalıştı");
            await _next(context);
            Console.WriteLine("1. middleware sona erdi");

        }
    }
}
