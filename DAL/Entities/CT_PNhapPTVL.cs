namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PNhapPTVL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string IDHANG { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ID_NHAPHANG { get; set; }

        public int SOLUONG { get; set; }

        public decimal TONGGT { get; set; }

        public virtual PhieuNhapHang PhieuNhapHang { get; set; }

        public virtual PhuTung_VatLieu PhuTung_VatLieu { get; set; }
    }
}
