using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASP_MVC_2.Models.DB;
using ASP_MVC_2.Models.ViewModel;

namespace ASP_MVC_2.Models.EntityManager
{
    public class OutbondManager
    {
        public void AddOutbond(OutbondView OV)
        {
            using (DemoEntities db = new DemoEntities())
            {

                outbond ob = new outbond();
                ob.keterangan = OV.keterangan;
                ob.harga = OV.harga;

                db.outbonds.Add(ob);
                db.SaveChanges();
            }
    }
}