using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MauSacService
    {
        public List<MauSac> GetAll()
        {
            Model1 context = new Model1();
            return context.MauSacs.ToList();
        }
    }
}
