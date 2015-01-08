using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartageMvc.Web.Models
{

    public class Container
    {
        public Container()
        {
            //create link

            this.DataContentId = 1;
            this.ContentType = 1;
            this.Link = "lien test";
            this.Visibility = 1;

            this.DateOnline = DateTime.Now;
        //    this.DateExpire = DateTime.Now;
             
        }

        public int Id { get; set; }

        [Required]
        public int DataContentId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required, MaxLength(255)]
        public string Link { get; set; }

        [Required]
        public int ContentType { get; set; }

        [Column("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        public int Visibility { get; set; }

        [Required]
        public DateTime DateOnline { get; set; }

        public DateTime? DateExpire { get; set; }

    }

}