using ResiliencePattern.Infastructure.Entities;
using ResiliencePattern.Infastructure.Repositories.Posts.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace ResiliencePattern.Infastructure.Repositories.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly HttpClient _httpClient;
        private readonly PostsUrlBuilder _postsUrlBuilder;
        private readonly PostRequestBuilder _postRequestBuilder;

        public PostRepository(HttpClient httpClient,
            PostsUrlBuilder postsUrlBuilder, PostRequestBuilder postRequestBuilder)
        {
            _httpClient = httpClient;
            _postsUrlBuilder = postsUrlBuilder;
            _postRequestBuilder = postRequestBuilder;
        }
        public async Task<PostEntityModel> AddPost(PostEntityModel post)
        {
            string url = _postsUrlBuilder.Build();

            var request = _postRequestBuilder
                           .WithPostData(post)
                           .Build();

            var response = await _httpClient.PostAsync(url,new StringContent(request));

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PostEntityModel>();

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
