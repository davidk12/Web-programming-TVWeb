using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TVWeb.Models;

namespace TVWeb.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index( )
		{
			CommentRepository rep = new CommentRepository( );
			var model = rep.GetComments( );
			return View( model );
		}

		[HttpPost]
		public ActionResult Index( FormCollection formData )
		{
			String strComment = formData["CommentText"];
			if ( !String.IsNullOrEmpty( strComment ) )
			{
				Comment c = new Comment( );
				CommentRepository rep = new CommentRepository( );

				c.CommentText = strComment;
				String strUser = System.Security.Principal.WindowsIdentity.GetCurrent( ).Name;
				if ( !String.IsNullOrEmpty( strUser ) )
				{
					int slashPos = strUser.IndexOf( "\\" );
					if ( slashPos != -1 )
					{
						strUser = strUser.Substring( slashPos + 1 );
					}
					c.UserName = strUser;

					rep.AddComment( c );
				}
				else
				{
					c.UserName = "Unknown user";
				}
				return RedirectToAction( "Index" );
			}
			else
			{
				ModelState.AddModelError( "CommentText", "Kjánaprik. Ætlarðu að setja inn tóma athugasemd?" );
				return Index( );
			}
		}

		public ActionResult About( )
		{
			return View( );
		}
	}
}
