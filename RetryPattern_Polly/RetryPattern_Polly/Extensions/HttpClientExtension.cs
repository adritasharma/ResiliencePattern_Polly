using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetryPattern.Infastructure.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetryPattern_Polly.Extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddHttpClientForPostService(
            this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddHttpClient<IPostRepository, PostRepository>(httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["Services:PostService:BasePath"]);
            });

            return serviceCollection;
        }
    }
}
