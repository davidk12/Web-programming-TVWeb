using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVWeb.Models
{
	public class CommentRepository
	{
		CommentDBDataContext m_db = new CommentDBDataContext( );

		public IEnumerable<Comment> GetComments( )
		{
			var result = from c in m_db.Comments
						 orderby c.CommentDate ascending
						 select c;

			return result;
		}

		public void AddComment( Comment c )
		{
			c.CommentDate = DateTime.Now;

			m_db.Comments.InsertOnSubmit( c );
			m_db.SubmitChanges( );
		}
	}
}