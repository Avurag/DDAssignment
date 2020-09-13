using DDAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CaptchaMvc.HtmlHelpers;

namespace DDAssignment.Controllers
{

    public class HomeController : Controller
    {
        private DDAssignmentEntities db = new DDAssignmentEntities();


        #region Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserVM objUser)
        {
            try
            {
                if (this.IsCaptchaValid("Captcha is not valid"))
                {
                    var obj = db.Users.Where(a => a.Username.Equals(objUser.Username) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserID.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        TempData["Success"] = string.Format("Login successful");
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["Alert"] = string.Format("Invalid username and password");
                    }

                }
                else
                {
                    TempData["Alert"] = string.Format("Captcha is not valid");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(objUser);
        }

        #endregion Login

        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            NameListVM obj = new NameListVM();
            try
            {
                obj.gridList = (from u in db.NameList
                                select new NameListVM
                                {
                                    SeqID = u.SeqID,
                                    Name = u.Name,
                                    CreatedOn = u.CreatedOn,
                                    UpdatedOn = u.UpdatedOn
                                }).ToList();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
            return View(obj);
        }

        [HttpPost]
        public JsonResult Index(NameList objName)
        {
            if (ModelState.IsValid)
            {
                NameList nameList = new NameList();
                try
                {
                    nameList.Name = objName.Name;
                    nameList.CreatedOn = DateTime.Now;
                    db.NameList.Add(nameList);
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    TempData["Alert"] = string.Format("Server error. Please contact administrator.");
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateName(NameList nameList)
        {
                NameList updatedNameList = (from c in db.NameList
                                            where c.SeqID == nameList.SeqID
                                            select c).FirstOrDefault();
                updatedNameList.Name = nameList.Name;
                updatedNameList.UpdatedOn = DateTime.Now;
                db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteName(int SeqID)
        {            
            {
                NameList nameList = (from c in db.NameList
                                     where c.SeqID == SeqID
                                     select c).FirstOrDefault();
                db.NameList.Remove(nameList);
                db.SaveChanges();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        #endregion Index


    }
}