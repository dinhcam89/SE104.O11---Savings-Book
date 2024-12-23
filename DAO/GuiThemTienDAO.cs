using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class GuiThemTienDAO
    {
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public DateTime GetNgayDaoHanKeTiep(int soTaiKhoanTienGoi)
        {
            string query = "SELECT NgayDaoHanKeTiep FROM PhieuGoiTien WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);
                conn.Open();

                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToDateTime(result) : DateTime.MinValue;
            }
        }

        public bool UpdateTongTienGoc(int soTaiKhoanTienGoi, float soTienGuiThem)
        {
            string query = "UPDATE PhieuGoiTien " +
                           "SET TongTienGoc = TongTienGoc + @SoTienGuiThem " +
                           "WHERE SoTaiKhoanTienGoi = @SoTaiKhoanTienGoi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoTaiKhoanTienGoi", soTaiKhoanTienGoi);
                cmd.Parameters.AddWithValue("@SoTienGuiThem", soTienGuiThem);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
