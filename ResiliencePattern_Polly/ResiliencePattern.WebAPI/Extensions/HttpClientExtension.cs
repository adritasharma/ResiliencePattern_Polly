using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using ResiliencePattern.Infastructure.Repositories.Employees;
using ResiliencePattern.Infastructure.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Polly.CircuitBreaker;

namespace ResiliencePattern_Polly.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddHttpClientForPostService(
            this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHttpClient<IPostRepository, PostRepository>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["Services:PostService:BasePath"]);
            }).AddPolicyHandler(GetRetryPolicy());

            return serviceCollection;
        }
        public static IServiceCollection AddHttpClientForEmployeeService(
            this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHttpClient<IEmployeeRepository, EmployeeRepository>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["Services:EmployeeManagementService:BasePath"]);
            }).AddPolicyHandler(GetRetryPolicy())
              .AddPolicyHandler(GetCircuitBreakerPolicy());

            return serviceCollection;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                // HttpRequestException, 5XX and 408  
                .HandleTransientHttpError()
                // 404  
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                // Retry two times after delay  
                //.WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)))
                .WaitAndRetryAsync(3, ComputeDuration, (result, timeSpan, retryCount, context) => {
                    Console.WriteLine($"Retry Count: {retryCount}, Exception: {result.Exception}");
                });
        }
        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            // if 2 consecutive errors occur, the circuit is cut for 30 seconds
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(30),(ex, t) =>
                {
                    Console.WriteLine("Circuit broken!");
                },
                () =>
                {
                    Console.WriteLine("Circuit Reset!");
                });
        }
        private static TimeSpan ComputeDuration(int retryAttempt)
        {
            return TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
        }
    }
}
