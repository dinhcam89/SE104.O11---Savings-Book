using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class ThamSoBUS
    {
        private ThamSoDAO _thamSoDAO;
        public ThamSoBUS()
        {
            _thamSoDAO = new ThamSoDAO();
        }
        public DTO.ThamSo? getThamSo()
        {
            return _thamSoDAO.getThamSo();
        }
        public bool updateThamSo(DTO.ThamSo thamSo)
        {
            return _thamSoDAO.updateThamSo(thamSo);
        }

    }
}
