using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThamSo
    {
        public string MaThamSo { get; set; }
        public double SoTienBanDauToiThieu { get; set; }
        public double SoTienGoiThemToiThieu { get; set; }

        public ThamSo() { }
        public ThamSo(string mathamso, double sotienbandautoithieu, double sotiengoithemtoithieu)
        {
            MaThamSo = mathamso;
            SoTienBanDauToiThieu = sotienbandautoithieu;
            SoTienGoiThemToiThieu = sotiengoithemtoithieu;
        }
    }
}
