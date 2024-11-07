using DAO;
using DTO;
using System;

namespace BUS
{
    public class SavingBookBUS
    {
        private SavingBookDAO savingBookDAO = new SavingBookDAO();

        public bool AddSavingBook(SavingBookDTO savingBook)
        {
            // Kiểm tra nếu dữ liệu hợp lệ trước khi lưu vào CSDL
            if (savingBook.SoTienGoi <= 0)
            {
                throw new Exception("Số tiền gửi phải lớn hơn 0.");
            }

            // Gọi phương thức DAO để thêm vào CSDL
            int result = savingBookDAO.InsertSavingBook(savingBook);
            return result > 0; // Nếu kết quả > 0, thêm thành công
        }
    }
}
