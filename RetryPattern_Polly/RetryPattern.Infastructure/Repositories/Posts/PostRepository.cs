using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Infastructure.Repositories.Posts
{
    public class PostRepository : IPostRepository
    {
        private readonly HttpClient _httpClient;

        public PostRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<PostEntityModel> GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntityModel> GetPostCommentsById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<PostEntityModel> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
