using RetryPattern.Infastructure.Entities;
using RetryPattern.Infastructure.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetryPattern.Infastructure.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IPostRepository _postRepository;

        public SampleRepository(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<IEnumerable<PostEntityModel>> GetSomeData()
        {
            return await _postRepository.GetPosts();
        }
    }
}
