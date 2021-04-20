using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetryPattern_Polly.Models
{
    public class PostVM
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
