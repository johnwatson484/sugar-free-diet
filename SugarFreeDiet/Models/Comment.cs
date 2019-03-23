using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SugarFreeDiet.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int CommentId { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime Created { get; set; }

        public string Text { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual List<Reply> Replies { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}