namespace MyWebApp.Models
{
    // This class represents one student (one row in the table)
    public class Student
    {
        public int Id { get; set; }           // Mã sinh viên
        public string? Name { get; set; }     // Họ tên
        public string? Email { get; set; }    // Email
        public string? Password { get; set; } // Mật khẩu
        public Branch? Branch { get; set; }   // Ngành học (nullable = can be empty)
        public Gender? Gender { get; set; }   // Giới tính (nullable)
        public bool IsRegular { get; set; }   // Hệ: true = Chính quy, false = Phi chính quy
        public string? Address { get; set; }  // Địa chỉ
        public DateTime DateOfBorth { get; set; } // Ngày sinh (matches lab spelling)
    }
}
