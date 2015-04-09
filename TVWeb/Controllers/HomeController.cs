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
			//var model = rep.GetComments( );
            CommentLikes stuff = new CommentLikes();
            stuff.comments = rep.GetComments();
            stuff.likes = rep.GetLikes();
			return View( stuff );
		}

		[HttpPost]
        public JsonResult Index(string comment)
		{
            if (!String.IsNullOrEmpty(comment))
            {
                Comment c = new Comment();
                CommentRepository rep = new CommentRepository();

                c.CommentText = comment;
                String strUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                if (!String.IsNullOrEmpty(strUser))
                {
                    int slashPos = strUser.IndexOf("\\");
                    if (slashPos != -1)
                    {
                        strUser = strUser.Substring(slashPos + 1);
                    }
                    c.UserName = strUser;

                    rep.AddComment(c);
                }
                else
                {
                    c.UserName = "Unknown user";
                }

                IEnumerable<Comment> comment_list = rep.GetComments();
                foreach (var co in comment_list)
                {
                    System.Diagnostics.Debug.WriteLine(co.ID);
                }
                return Json(comment_list, JsonRequestBehavior.AllowGet);

                //return Json(c, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError("CommentText", "Silly goose, you gonna comment with nothing?");
                return Json("Could not add comment", JsonRequestBehavior.AllowGet);
            }
		}


        [HttpPost]
        public JsonResult Index2(int id)
        {

            //bool does_exist = false;
            string strUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            strUser = do_magic(strUser);

            CommentRepository rep = new CommentRepository();
            IEnumerable<Like> mtndew = rep.GetLikes();
            bool comp;

            string cur_user;
            
            Like l = new Like();
           
            if (!string.IsNullOrEmpty(strUser))
            {
                foreach (var yay in mtndew)
                {
                    cur_user = yay.UserName;
                    comp = cur_user == strUser;

                    if (yay.CommentID == id && comp)
                    {
                        
                        return Json(null, JsonRequestBehavior.AllowGet);
                    }
                }

                int slashPos = strUser.IndexOf("\\");
                if (slashPos != -1)
                {
                    strUser = strUser.Substring(slashPos + 1);
                }
                l.UserName = strUser;
                l.CommentID = id;

                rep.AddLike(l);
                
                // System.Diagnostics.Debug.WriteLine(l.UserName);


                return Json(l, JsonRequestBehavior.AllowGet);
                
            }
            else
            {
                l.UserName = "Unknown user";
                return Json("Unknown user", JsonRequestBehavior.AllowGet);
            }
        }

		public ActionResult About( )
		{
			return View( );
		}

        String do_magic(String beaver)
        {
            int slashPos = beaver.IndexOf("\\");
            if (slashPos != -1)
            {
                beaver = beaver.Substring(slashPos + 1);
            }

            return beaver;
        }
	}
}
