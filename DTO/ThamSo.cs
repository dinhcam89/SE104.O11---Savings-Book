using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThamSo
    {
        public double SoTienBanDauToiThieu { get; set; }
        public double SoTienGoiThemToiThieu { get; set; }

        public ThamSo() { }
        public ThamSo(double sotienbandautoithieu, double sotiengoithemtoithieu)
        {
            SoTienBanDauToiThieu = sotienbandautoithieu;
            SoTienGoiThemToiThieu = sotiengoithemtoithieu;
        }
    }
}
