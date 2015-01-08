using PartageMvc.Web.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartageMvc.Web.Models
{
    public class Container
    {
        public int Id { get; set; }

        [Required]
        public string DataContentId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required, MaxLength(255)]
        public string Link { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Column("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        public int Visibility { get; set; }

        [Required]
        public DateTime DateOnline { get; set; }

        public DateTime? DateExpire { get; set; }

        public static Container Create(string dataContentId, IContentType type)
        {
            return new Container
            {
                DataContentId = dataContentId,
                Visibility = 1,
                DateOnline = DateTime.Now,
                ContentType = PartageMvc.Web.Core.ContentType.GetKey(type),
                Link = Guid.NewGuid().ToString("N")
            };
        }
    }
}