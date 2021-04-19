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

        public Task<Post> GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostCommentsById(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPosts()
        {
            throw new NotImplementedException();
        }
    }
}
