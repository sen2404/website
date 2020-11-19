using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
       DBConnect db = new DBConnect();
        
        public static object Encodings { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                var ma_hoa = GetMD5(Password);
                var kiem_tra = db.KhachHangs.Where(kh => kh.Email.Equals(Email) && kh.Password.Equals(ma_hoa)).ToList();
                if (kiem_tra != null)
                {
                    Session["MaKKH"] = kiem_tra.FirstOrDefault().MaKhachHang;
                    Session["TenKH"] = kiem_tra.FirstOrDefault().TenKhachHang;
                    return RedirectToAction("Index");
                }    
                else
                {
                    ViewBag.error = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }    
            }    

                return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }



        public ActionResult Register()
        {
            return View();
        }
       [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Register(KhachHang khach)
        {
            if(ModelState.IsValid)
            {
                var check = db.KhachHangs.FirstOrDefault(s => s.Email == khach.Email);
                if(check==null)
                {
                    khach.Password = GetMD5(khach.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KhachHangs.Add(khach);

                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Email đã tồn tại";
                    return RedirectToAction("Register");
                }    
            }    
            return View();
        }
        private object GetMD5(object password)
        {
            throw new NotImplementedException();
        }

        public static string GetMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string da_ma_hoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                da_ma_hoa += targetData[i].ToString("x2");

            }
            return da_ma_hoa;
        }


    }
}