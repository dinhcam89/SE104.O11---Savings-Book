using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThamSo
    {
        public double SoTienGuiBanDauToiThieu { get; set; }
        public double SoTienGuiThemToiThieu { get; set; }

        public ThamSo() { }
        public ThamSo(double sotienguibandautoithieu, double sotienguithemtoithieu)
        {
            SoTienGuiBanDauToiThieu = sotienguibandautoithieu;
            SoTienGuiThemToiThieu = sotienguithemtoithieu;
        }
    }
}
