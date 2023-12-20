using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class NhanVienService
    {

        public List<NhanVien> GetAll()
        {
            Model1 context = new Model1();
            return context.NhanViens.ToList();
        }
        public List<NhanVien> checkform(NhanVien nv)
        {
            var context = new Model1();
            List<NhanVien> lg = context.NhanViens.ToList();
            return lg;
        }
    }
}
