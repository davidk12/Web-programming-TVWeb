using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVWeb.Models
{
	public class CommentRepository
	{
        commentsDBDataContext m_db = new commentsDBDataContext();

		public IEnumerable<Comment> GetComments( )
		{
			var result = from c in m_db.Comments
						 orderby c.CommentDate ascending
						 select c;
			return result;
		}

        public IEnumerable<Like> GetLikes()
        {
            var result = from l in m_db.Likes
                         orderby l.CommentID ascending
                         select l;
            return result;
        }

		public void AddComment( Comment c )
		{
			c.CommentDate = DateTime.Now;

			m_db.Comments.InsertOnSubmit( c );
			m_db.SubmitChanges( );
		}

        public void AddLike(Like l)
        {
            m_db.Likes.InsertOnSubmit( l );
            m_db.SubmitChanges( );
        }
	}
}