using System;
using System.Collections.Generic;
using System.Text;

namespace RetryPattern.Infastructure.Repositories.Posts.Contracts
{
    public class PostsUrlBuilder
    {
        private readonly UriBuilder _uriBuilder = new UriBuilder();

        public PostsUrlBuilder()
        {
            _uriBuilder.Path = ServiceRoutes.Post.Base;
        }

        public string Build()
        {
            return _uriBuilder.Uri.PathAndQuery;
        }
    }
}
