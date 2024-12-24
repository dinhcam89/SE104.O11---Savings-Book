﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class HienThiChiTietRutTienBUS
    {
        private DAO.HienThiChiTietRutTienDAO hienthichitietrut = new DAO.HienThiChiTietRutTienDAO();

        public List<DTO.ChiTietRutTien> GetAllChiTietRutTien()
        {
            return hienthichitietrut.GetAll();
        }
    }
}
