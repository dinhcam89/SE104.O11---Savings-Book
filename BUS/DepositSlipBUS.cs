using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;

namespace BUS
{
    public class DepositSlipBUS
    {
        private DepositSlipDAO depositReceiptDAO;

        public DepositSlipBUS()
        {
            depositReceiptDAO = new DepositSlipDAO();
        }

        public bool AddDepositReceipt(DepositSlipDTO receipt)
        {
            // Kiểm tra các điều kiện hợp lệ trước khi thêm
            if (receipt == null ||
                string.IsNullOrEmpty(receipt.SavingBookId) ||
                string.IsNullOrEmpty(receipt.CustomerName) ||
                receipt.DepositAmount <= 0 ||
                receipt.DepositDate == default)
            {
                return false; // Thông tin không hợp lệ
            }

            // Gọi DAO để thực hiện việc thêm phiếu gửi tiền
            return depositReceiptDAO.AddDepositReceipt(receipt);
        }
    }
}
