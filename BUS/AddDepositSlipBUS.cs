using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    internal class AddDepositSlipBUS
    {
        private AddDepositSlipDAO adddepositslipDAL;

        public AddDepositSlipBUS()
        {
            adddepositslipDAL = new AddDepositSlipDAO();
        }

        // Phương thức xử lý thêm phiếu rút tiền
        public bool AddWithdrawal(DepositSlipDTO depositslipDTO)
        {
            // Kiểm tra nghiệp vụ, ví dụ: số tiền rút phải hợp lệ
            if (depositslipDTO.DepositAmount <= 0)
            {
                throw new ArgumentException("Số tiền rút phải lớn hơn 0.");
            }

            // Thêm phiếu rút tiền vào cơ sở dữ liệu và cập nhật sổ tiết kiệm
            return adddepositslipDAL.AddDeposit(depositslipDTO);
        }
    }
}
