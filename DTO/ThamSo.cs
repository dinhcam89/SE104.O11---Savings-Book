using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThamSo
    {
        public float SoTienBanDauToiThieu { get; set; }
        public float SoTienGoiThemToiThieu { get; set; }

        // Constructor
        public ThamSo(float soTienBanDauToiThieu, float soTienGoiThemToiThieu)
        {
            SoTienBanDauToiThieu = soTienBanDauToiThieu;
            SoTienGoiThemToiThieu = soTienGoiThemToiThieu;
        }
    }
}
