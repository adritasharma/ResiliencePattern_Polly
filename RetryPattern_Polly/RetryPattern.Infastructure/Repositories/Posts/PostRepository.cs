using RetryPattern.Infastructure.Entities;
using RetryPattern.Infastructure.Repositories.Posts.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace RetryPattern.Infastructure.Repositories.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly HttpClient _httpClient;
        private readonly PostsUrlBuilder _postsUrlBuilder;

        public PostRepository(HttpClient httpClient, PostsUrlBuilder postsUrlBuilder)
        {
            _httpClient = httpClient;
            _postsUrlBuilder = postsUrlBuilder;
        }

        public Task<PostEntityModel> GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntityModel> GetPostCommentsById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostEntityModel>> GetPosts()
        {
            string url = _postsUrlBuilder.Build();

            return _httpClient.GetFromJsonAsync<IEnumerable<PostEntityModel>>(url);
        }
    }
}
