using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAO
{
    public class LoaiTietKiemDAO
    {
        private DatabaseConnection dbConnection;

        public LoaiTietKiemDAO()
        {
            dbConnection = new DatabaseConnection();
        }

        public List<LoaiTietKiem> getAllLoaiTietKiem()
        {
            string query = "SELECT * FROM LoaiTietKiem";
            List<LoaiTietKiem> listLoaiTietKiem = new List<LoaiTietKiem>();
            DataTable? dataTable = dbConnection.executeSelectQuery(query, null);

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    LoaiTietKiem loaiTietKiem = new LoaiTietKiem
                    {
                        MaLoaiTietKiem = row["MaLoaiTietKiem"].ToString()!,
                        KyHan = int.Parse(row["KyHan"].ToString()!),
                        SoNgayToiThieuDuocRutTien = int.Parse(row["SoNgayToiThieuDuocRutTien"].ToString()!),
                        QuyDinhSoTienRut = row["QuyDinhSoTienRut"].ToString()!
                    };
                    listLoaiTietKiem.Add(loaiTietKiem);
                }
            }
            return listLoaiTietKiem;
        }

        public LoaiTietKiem? getLoaiTietKiem(LoaiTietKiem ltk)
        {
            string query = "SELECT * FROM LoaiTietKiem WHERE MaLoaiTietKiem = @MaLoaiTietKiem";
            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@MaLoaiTietKiem", ltk.MaLoaiTietKiem),
            };
            DataTable? dataTable = dbConnection.executeSelectQuery(query, sqlParameters);

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new LoaiTietKiem
                {
                    MaLoaiTietKiem = row["MaLoaiTietKiem"].ToString()!,
                    KyHan = int.Parse(row["KyHan"].ToString()!),
                    SoNgayToiThieuDuocRutTien = int.Parse(row["SoNgayToiThieuDuocRutTien"].ToString()!),
                    QuyDinhSoTienRut = row["QuyDinhSoTienRut"].ToString()!
                };
            }
            return null;
        }

        public bool updateLoaiTietKiem(LoaiTietKiem ltk)
        {
            string query = @"
                UPDATE LoaiTietKiem
                SET KyHan = @KyHan,
                    LaiSuat = @LaiSuat,
                    SoNgayToiThieuDuocRutTien = @SoNgayToiThieuDuocRutTien,
                    QuyDinhSoTienRut = @QuyDinhSoTienRut
                WHERE MaLoaiTietKiem = @MaLoaiTietKiem";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@KyHan", ltk.KyHan),
                new SqlParameter("@LaiSuat", ltk.LaiSuat),
                new SqlParameter("@SoNgayToiThieuDuocRutTien", ltk.SoNgayToiThieuDuocRutTien),
                new SqlParameter("@QuyDinhSoTienRut", ltk.QuyDinhSoTienRut),
                new SqlParameter("@MaLoaiTietKiem", ltk.MaLoaiTietKiem)
            };

            return dbConnection.executeUpdateQuery(query, sqlParameters);
        }

        public bool deleteLoaiTietKiem(LoaiTietKiem ltk)
        {
            string query = "DELETE FROM LoaiTietKiem WHERE MaLoaiTietKiem = @MaLoaiTietKiem";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@MaLoaiTietKiem", ltk.MaLoaiTietKiem),
            };

            return dbConnection.executeUpdateQuery(query, sqlParameters);
        }

        public bool insertLoaiTietKiem(int kyHan, double laiSuat, int soNgayToiThieuDuocRutTien, string quyDinhSoTienRut)
        {
            string query = @"
                INSERT INTO LoaiTietKiem (KyHan, LaiSuat, SoNgayToiThieuDuocRutTien, QuyDinhSoTienRut)
                VALUES (@KyHan, @LaiSuat, @SoNgayToiThieuDuocRutTien, @QuyDinhSoTienRut)";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@KyHan", kyHan),
                new SqlParameter("@LaiSuat", laiSuat),
                new SqlParameter("@SoNgayToiThieuDuocRutTien", soNgayToiThieuDuocRutTien),
                new SqlParameter("@QuyDinhSoTienRut", quyDinhSoTienRut),
            };

            return dbConnection.executeUpdateQuery(query, sqlParameters);
        }
    }
}
