using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QL_TrungTam_X.Areas.QuanLy.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập username!")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Vui lòng nhập password!")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}