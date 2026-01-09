//using Civitan.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopekaMustangClubInc.Models
{
    public class EmailQueueVM
    {
        public static List<string> SelectedList { get; set; }
        public EmailQueue? EmailQueue { get; set; }
        public string? AttachmentUrl { get; set; }
        //public static UserVM? UserVM { get; set; }
    }

    public class CheckItems
    {
        public int? Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserRole { get; set; }
        public string? Email { get; set; }
        public bool IsChecked { get; set; }
        public string? Full_Name { get; set; }
        public string? Message { get; set; }
    }

}
