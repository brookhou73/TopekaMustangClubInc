using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Civitan.Models.ViewModels;

namespace TopekaMustangClubInc.Models
{
    public class EmailQueue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "TO")]
        public List<string>? SelectedList { get; set; }

        
        [Display(Name = "CC")]
        public string? Cc { get; set; }

        
        [Display(Name = "BCC")]
        public string? Bcc { get; set; }

        [Required]
        [Display(Name = "SUBJECT")]
        public string? Subject { get; set; }

        [Required]
        [Display(Name = "MESSAGE")]
        public string? Message { get; set; }

        
        [Display(Name = "ATTACHMENT")]
        public string? AttachmentURL { get; set; }

        [Required]
        [Display(Name = "FULL NAME")]
        public string? FullName { get; set; }

        [TempData]
        public static string StatusMessage { get; set; }


        //public List<UserRepository> UserList { get; set; }
        public int Cnt { get; set; }
        [BindProperty]
        public List<CheckItems> CheckboxList { get; set; }
        //public string SelectedList { get; set; }
        public EmailQueue()
        {
            //UserList = new List<UserRepository>();
        }
    }
}
