using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace ASP_MVC_2.Models.ViewModel
{
    public class OutbondView
    {
        [Key]
        public int id_outbond { get; set; }
        
        [Required(ErrorMessage = "*")]
        [Display(Name = "keterangan")]
        public string keterangan { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "harga")]
        public int harga { get; set; }
    }
}