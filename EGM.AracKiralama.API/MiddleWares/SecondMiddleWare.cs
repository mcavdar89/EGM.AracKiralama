namespace EGM.AracKiralama.API.MiddleWares
{
    public class SecondMiddleWare
    {
        private RequestDelegate _next;
        public SecondMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("2. middleware çalıştı");
            await _next.Invoke(context);
            Console.WriteLine("2. middleware sona erdi");

        }
    }
}
