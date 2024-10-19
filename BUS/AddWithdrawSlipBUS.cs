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

        public bool CheckBookTerm(string savingBookID)
        {
            // Gọi DAO để lấy thông tin DepositSlipDTO và BookTypeDTO
            (DepositSlipDTO depositSlip, BookType bookType) = addwithdrawslipDAL.SavingBookInfo(savingBookID);

            if (depositSlip == null || bookType == null)
            {
                throw new Exception("Không tìm thấy thông tin sổ tiết kiệm hoặc loại sổ.");
            }

            // Xử lý kiểm tra kỳ hạn
            if (bookType.BookTerm == "Không kỳ hạn")
            {
                // Không có kỳ hạn, kiểm tra nếu đã qua 15 ngày
                return (DateTime.Now - depositSlip.DepositDate.ToDateTime(TimeOnly.MinValue)).TotalDays >= 15;
            }
            else
            {
                // Với các sổ có kỳ hạn (3 tháng, 6 tháng, ...)
                int months = int.Parse(bookType.BookTerm.Split(' ')[0]);  // Lấy số tháng từ chuỗi BookTerm (vd: "3 tháng")
                return depositSlip.DepositDate.AddMonths(months) <= DateOnly.FromDateTime(DateTime.Now);
            }
        }

    }
}
