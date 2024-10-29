using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        #region Properties
        public int MaSo { get; set; }
        public string TenKhachHang { get; set; }
        public DateOnly SinhNhat { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string CCCD { get; set; }
        #endregion

        #region Constructors
        public CustomerDTO() { }
        public CustomerDTO(int maSo, string tenKhachHang, DateOnly ngaySinh, string diaChi, string soDienThoai, string cccd)
        {
            MaSo = maSo;
            TenKhachHang = tenKhachHang;
            SinhNhat = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            CCCD = cccd;
        }
        #endregion
    }
}
