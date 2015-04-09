using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVWeb.Models
{
    public class CommentLikes
    {
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<Like> likes { get; set; }

        public bool do_shit(int comment_ID, int like_ID)
        {
            return comment_ID == like_ID;
        }


    }
}