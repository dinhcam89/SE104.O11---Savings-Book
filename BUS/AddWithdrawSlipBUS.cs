using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    internal class AddWithdrawSlipBUS
    {
        private AddWithdrawSlipDAO addwithdrawslipDAL;

        public AddWithdrawSlipBUS()
        {
            addwithdrawslipDAL = new AddWithdrawSlipDAO();
        }

        public bool AddWithdrawal(WithdrawSlipDTO withdrawslipDTO)
        {
            // Kiểm tra nghiệp vụ, ví dụ: số tiền rút phải hợp lệ
            if (withdrawslipDTO.WithdrawAmount <= 0)
            {
                throw new ArgumentException("Số tiền rút phải lớn hơn 0.");
            }
            // Thêm phiếu rút tiền vào cơ sở dữ liệu và cập nhật sổ tiết kiệm
            return addwithdrawslipDAL.addWithdrawSlip(withdrawslipDTO);
        }
    }
}
