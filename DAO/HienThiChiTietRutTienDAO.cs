﻿using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HienThiChiTietRutTienDAO
    {
        private string connectionString = "Data Source=CONALNGUYEN\\NGUYENCHAU;Initial Catalog=saving_books_management;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        public List<DTO.ChiTietRutTien> GetAll()
        {
            List<DTO.ChiTietRutTien> list = new List<DTO.ChiTietRutTien>();

            string query = "SELECT MaChiTietRutTien, SoTaiKhoanTienGoi, NgayRut, SoTienRut FROM ChiTietRutTien";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.ChiTietRutTien
                        {
                            MaChiTietRutTien = reader["MaChiTietRutTien"].ToString(),
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayRut = Convert.ToDateTime(reader["NgayRut"]),
                            SoTienRut = Convert.ToDouble(reader["SoTienRut"])
                        };

                        list.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return list;
        }

        public List<ChiTietRutTien> GetByMaPhieu(string maPhieu)
        {
            List<ChiTietRutTien> listChiTiet = new List<ChiTietRutTien>();
            string query = "SELECT MaChiTietRutTien, SoTaiKhoanTienGoi, NgayRut, SoTienRut FROM ChiTietRutTien WHERE SoTaiKhoanTienGoi = @MaPhieu";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaPhieu", maPhieu);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new ChiTietRutTien
                        {
                            MaChiTietRutTien = reader["MaChiTietRutTien"].ToString(),
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayRut = Convert.ToDateTime(reader["NgayRut"]),
                            SoTienRut = Convert.ToDouble(reader["SoTienRut"])
                        };

                        listChiTiet.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return listChiTiet;
        }

        public List<DTO.ChiTietRutTien> GetTenKhachHang()
        {
            List<DTO.ChiTietRutTien> list = new List<DTO.ChiTietRutTien>();

            string query = @"
        SELECT 
            CTG.MaChiTietRutTien, 
            CTG.SoTaiKhoanTienGoi, 
            KH.TenKhachHang, 
            CTG.NgayRut, 
            CTG.SoTienRut
        FROM ChiTietRutTien CTG
        JOIN PhieuGoiTien PG ON CTG.SoTaiKhoanTienGoi = PG.SoTaiKhoanTienGoi
        JOIN KhachHang KH ON PG.SoTaiKhoanThanhToan = KH.SoTaiKhoanThanhToan";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.ChiTietRutTien
                        {
                            MaChiTietRutTien = reader["MaChiTietRutTien"].ToString(),
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
                            TenKhachHang = reader["TenKhachHang"].ToString(),
                            NgayRut = Convert.ToDateTime(reader["NgayRut"]),
                            SoTienRut = (float)Convert.ToDouble(reader["SoTienRut"])
                        };

                        list.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return list;
        }
        public List<DTO.ChiTietRutTien> GetNgay(DateTime startDate, DateTime endDate)
        {
            List<DTO.ChiTietRutTien> list = new List<DTO.ChiTietRutTien>();

            string query = @"
        SELECT MaChiTietRutTien, SoTaiKhoanTienGoi, NgayRut, SoTienRut
        FROM ChiTietRutTien
        WHERE NgayRut >= @StartDate AND NgayRut <= @EndDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var chiTiet = new DTO.ChiTietRutTien
                        {
                            MaChiTietRutTien = reader["MaChiTietRutTien"].ToString(),
                            SoTaiKhoanTienGui = reader["SoTaiKhoanTienGoi"].ToString(),
                            NgayRut = Convert.ToDateTime(reader["NgayRut"]),
                            SoTienRut = Convert.ToDouble(reader["SoTienRut"])
                        };

                        list.Add(chiTiet);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi truy vấn dữ liệu: " + ex.Message);
                }
            }

            return list;
        }
    }
}
