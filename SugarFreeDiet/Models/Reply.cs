using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SugarFreeDiet.Models
{
    [Table("Replies")]
    public class Reply
    {
        public int ReplyId { get; set; }

        public int CommentId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime Created { get; set; }

        public string Text { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}