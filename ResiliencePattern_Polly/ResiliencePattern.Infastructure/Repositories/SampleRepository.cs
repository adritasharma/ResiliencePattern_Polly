using ResiliencePattern.Infastructure.Entities;
using ResiliencePattern.Infastructure.Repositories.Posts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResiliencePattern.Infastructure.Repositories
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
