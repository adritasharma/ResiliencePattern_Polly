using ResiliencePattern.Infastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ResiliencePattern.Infastructure.Repositories.Posts
{
    public class PostRequestBuilder
    {
        private PostEntityModel _post;

        public PostRequestBuilder WithPostData(PostEntityModel post)
        {
            _post = post;
            return this;
        }
        public string Build()
        {
            var request = new
            {
                id = _post.Id,
                title = _post.Title,
                body = _post.Body,
                userId = _post.UserId
            };

            return JsonSerializer.Serialize(request);
        }
    }
}
