using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Infastructure.Repositories.Posts
{
    public interface IPostRepository
    {
        public  Task<Post> GetPosts();
        public Task<Post> GetPostById(int postId);
        public Task<Post> GetPostCommentsById(int postId);
    }
}
