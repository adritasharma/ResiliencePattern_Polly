using System;
using System.Collections.Generic;
using System.Text;

namespace ResiliencePattern.Core.ServiceModels
{
    public class PostServiceModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
