using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    /// <summary>
    /// Thông tin khách hàng
    /// CreatedBy: NXQuang (01/04/2021)
    /// </summary>
    public class Customer: BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        ///  Họ và tên
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        ///  Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0- Nữ, 1- Nam)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        ///  ID đơn vị
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        ///  Khóa ngoại (FK) - nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Chức danh nhân viên
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Chi nhánh khoản ngân hàng
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        ///  Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// SĐT cố định
        /// </summary>
        public string TelephoneNumber { get; set; }

        /// <summary>
        /// Số CMND
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Nơi cấp CMND
        /// </summary>
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public string IdentityDate { get; set; }
        /// <summary>
        /// Nơi ở
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Email khách hàng
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Email khách hàng
        /// </summary>
        public string BankProvinceName { get; set; }
    }
}
