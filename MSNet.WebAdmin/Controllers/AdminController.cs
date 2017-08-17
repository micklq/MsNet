using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using M2SA.AppGenome;
using M2SA.AppGenome.Data;
using MSNet.Common.Web;
using MSNet.Common.Util;
using MSNet.Common.Web.Pager;
using MSNet.Common.Passports;
namespace MSNet.WebAdmin.Controllers
{
    public partial class AdminController : AuthBaseController
    {
        //
        // GET: /Admin/

        public ActionResult List()
        {
            var page = new Pagination
            {
                PageIndex = Request["page"].ToInt(1),
                PageSize = 10
            };
            var keyword = "";
            if (!Request["uname"].IsNullOrEmpty())
            {
                keyword = Request["uname"];
            }
            var exceptIds = new List<long> { (long)0 };
            IList<UserPassport> ulist = UserPassport.FindWithAdminPage(keyword, exceptIds, page); //排除自己;

            PagedList<UserPassport> plist = null;
            if (ulist != null)
            {
                plist = new PagedList<UserPassport>(ulist.ToList(), page.PageIndex, page.PageSize, page.TotalCount);
            }

            ViewData["AdminList"] = plist;
            return View();
        }


        [HttpPost]
        public ActionResult AdminAction(UserPassport model)
        {
            if (model.UserName.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入用户名！"
                }, JsonRequestBehavior.AllowGet);
            }
            var rbool = true;
            if (model.PassportId < 1)
            {
                if (model.Password.IsNullOrEmpty())
                {
                    return Json(new
                    {
                        success = false,
                        message = "请输入密码！"
                    }, JsonRequestBehavior.AllowGet);
                }

                SignUpStatus status;
                rbool = MemberShip.Add(model, GetSignedUpInfo(), out status);
                if (!rbool)
                {
                    if (status == SignUpStatus.None || status == SignUpStatus.Error)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "系统异常,请稍后重试！"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    if (status == SignUpStatus.InvalidUserName)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "用户名格式错误！"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    if (status == SignUpStatus.InvalidEmail)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "邮箱格式错误！"
                        }, JsonRequestBehavior.AllowGet);
                    }

                    if (status == SignUpStatus.InvalidMobilePhone)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "手机格式错误！"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    if (status == SignUpStatus.DuplicateUserName)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "用户名已存在！"
                        }, JsonRequestBehavior.AllowGet);
                    }

                    if (status == SignUpStatus.DuplicateEmail)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "邮箱已存在！"
                        }, JsonRequestBehavior.AllowGet);
                    }
                    if (status == SignUpStatus.DuplicateMobilePhone)
                    {
                        return Json(new
                        {
                            success = false,
                            message = "手机号码已存在！"
                        }, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(new
                {
                    success = true,
                    message = "添加成功！"
                }, JsonRequestBehavior.AllowGet);

            }

            var u = UserPassport.FindUserSecurityById(model.PassportId);
            if (u == null)
            {
                return Json(new
                {
                    success = false,
                    message = "用户数据不存在！"
                }, JsonRequestBehavior.AllowGet);
            }
            var existUserName = UserPassport.FindPassportIdByUserName(model.UserName);
            if (existUserName > 0 && existUserName != model.PassportId)
            {
                return Json(new
                {
                    success = false,
                    message = "用户名已存在！"
                }, JsonRequestBehavior.AllowGet);
            }
            var existEmail = UserPassport.FindPassportIdByEmail(model.Email);
            if (existEmail > 0 && existEmail != model.PassportId)
            {
                return Json(new
                {
                    success = false,
                    message = "邮箱已存在！"
                }, JsonRequestBehavior.AllowGet);
            }
            var existMobile = UserPassport.FindPassportIdByMobile(model.Mobile);
            if (existMobile > 0 && existMobile != model.PassportId)
            {
                return Json(new
                {
                    success = false,
                    message = "手机已存在！"
                }, JsonRequestBehavior.AllowGet);
            }
            rbool = MemberShip.Update(model, GetSignedUpInfo());
            if (!rbool)
            {
                return Json(new
                {
                    success = false,
                    message = "系统异常,请稍后重试！"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = true,
                message = "操作成功！"
            }, JsonRequestBehavior.AllowGet);

        }



        public ActionResult ModifyPassword()
        {
            if (this.CurrentUser.PassportId == 0)
            {
                return Redirect("/pub/ErrorMsg?returnUrl=/admin/list");
            }
            var users = UserPassport.FindById(this.CurrentUser.PassportId);
            if (users == null)
            {
                return Redirect("/pub/ErrorMsg?returnUrl=/admin/list");
            }
            ViewData["Users"] = users;
            return View();
        }

        [HttpPost]
        public ActionResult ModifyCurrUserPassword()
        {
            long passportId = this.CurrentUser.PassportId;
            string oPassword = Request["oPassword"].ToString(),
                nPasspword = Request["nPasspword"].ToString();
            if (passportId < 1)
            {
                return Json(new
                {
                    success = false,
                    message = "参数错误！"
                }, JsonRequestBehavior.AllowGet);
            }
            if (oPassword.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入旧密码！"
                }, JsonRequestBehavior.AllowGet);
            }
            if (nPasspword.IsNullOrEmpty())
            {
                return Json(new
                {
                    success = false,
                    message = "请输入新密码！"
                }, JsonRequestBehavior.AllowGet);
            }
            var rbool = MemberShip.ModifyPassword(passportId, oPassword, nPasspword);
            if (!rbool)
            {
                return Json(new
                {
                    success = false,
                    message = "系统异常,请稍后重试！"
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                success = true,
                message = "修改成功！"
            }, JsonRequestBehavior.AllowGet);

        }


    }
}
