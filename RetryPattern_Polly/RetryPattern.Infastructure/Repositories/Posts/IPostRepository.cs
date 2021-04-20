using RetryPattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Infastructure.Repositories.Posts
{
    public interface IPostRepository
    {
        public Task<IEnumerable<PostEntityModel>> GetPosts();
        public Task<PostEntityModel> GetPostById(int postId);
        public Task<PostEntityModel> GetPostCommentsById(int postId);
    }
}
