using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Web.Data.Entities
{
    public class BlogCommentEntity : EntityBase
    {
        public int UserId { get; set; }
        public int BlogPostId { get; set; }
        [MaxLength(200)]
        public string Message { get; set;}
    }
}
