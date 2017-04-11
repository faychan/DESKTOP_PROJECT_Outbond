using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ASP_MVC_2.Models.ViewModel
{
    public class LaporanModel
    {
        public int? SelectedRoleID { get; set; }
        public IEnumerable<LOOKUPAvailableRole> UserRoleList { get; set; }
    }
}