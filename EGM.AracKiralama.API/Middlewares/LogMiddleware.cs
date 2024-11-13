﻿using EGM.AracKiralama.BL.Abstracts;
using EGM.AracKiralama.Model.Entities;
using System.Text;
using System.Transactions;

namespace EGM.AracKiralama.API.Middlewares
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

            var originalBodyStream = context.Response.Body;//aa12
            await using var responseBody = new MemoryStream();//bc23
            context.Response.Body = responseBody;//bc23
            try
            {

                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    int userId = Convert.ToInt32(context.User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);

                    string requestBody = await ReadRequestBodyAsync(context.Request);

                    await _next.Invoke(context);
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


                    responseBody.Position = 0;
                    await responseBody.CopyToAsync(originalBodyStream);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                context.Response.Body = originalBodyStream;
            }



        }



        private async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.EnableBuffering();
            request.Body.Position = 0;
            using var reader = new StreamReader(request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, leaveOpen: true);
            var body = await reader.ReadToEndAsync();
            request.Body.Position = 0;
            return body;


        }

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