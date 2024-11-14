
using Infra.BL.Abstracts;
using Infra.Model.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Transactions;

namespace Infra.API.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILogService logService)
        {

            var transctionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            };




            var stratTime = DateTime.UtcNow;

            var originalBodyStream = context.Response.Body;
            // Akışı kapatmadan işlemi yapabilmek için yeni bir MemoryStream oluşturun
            var memoryStream = new MemoryStream();
            await using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;//bc23
            try
            {

                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    //string requestBody = await ReadRequestBodyAsync(context.Request);
                    string requestBody = "";

                    // İstek gövdesini MemoryStream'e kopyalayın
                    await context.Request.Body.CopyToAsync(memoryStream);

                    // Başlangıca dönerek tekrar okuma için sıfırlayın
                    memoryStream.Position = 0;
                    context.Request.Body = memoryStream;

                    // İsteğin gövdesini bir kere okuyup loglayabilirsiniz
                    requestBody = await new StreamReader(memoryStream).ReadToEndAsync();
                    //Console.WriteLine($"Request Body: {requestBody}");

                    // Okuma işlemi için tekrar başa döndürün
                    memoryStream.Position = 0;




                    await _next.Invoke(context);

                    int userId = Convert.ToInt32(context.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);


                    responseBody.Position = 0;
                    string responseText = await new StreamReader(responseBody).ReadToEndAsync();

                    //await ReadResponseBodyAsync(responseBody);

                    LogTable log = new LogTable()
                    {
                        StatusId = 1,
                        UserId = userId,
                        RequestPath = context.Request.Path,
                        RequestBody = requestBody,
                        ResponseBody = responseText,
                        ApplicationId = 1,
                        IpAddress = context.Connection.RemoteIpAddress.ToString(),
                        LastTransactionDate = DateTime.Now,

                    };

                    await logService.AddLogAsync(log);

                    transactionScope.Complete();



                }

            }
            catch (Exception ex)
            {

                //throw;
            }
            finally
            {
                //context.Response.Body = originalBodyStream;
                responseBody.Position = 0;
                await responseBody.CopyToAsync(originalBodyStream);

                memoryStream.Dispose();
            }



        }



        //private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        //{

        //    var reader = request.BodyReader;
        //    var readResult = await reader.ReadAsync();
        //    var buffer = readResult.Buffer;



        //    ///request.EnableBuffering();
        //    //request.Body.Seek(0, SeekOrigin.Begin);
        //    //using var reader = new StreamReader(request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
        //    //var body = await reader.ReadToEndAsync();
        //    //request.Body.Position = 0;
        //    //return body;


        //}

        private async Task<string> ReadResponseBodyAsync(Stream responseBody)
        {
            responseBody.Position = 0;
            using var reader = new StreamReader(responseBody);
            var body = await reader.ReadToEndAsync();
            responseBody.Position = 0;
            return body;
        }





    }
}
