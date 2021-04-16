using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Api cho đối tượng khách hàng
    /// </summary>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        /// CreatedBy: NXQuang (01/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            // Khởi tạo kết nối tới Database:
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.AMIS";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện lấy dữ liệu từ Database:

            var customers = dbConnection.Query<Customer>("Proc_GetEmployees", commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (customers.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(customers);
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="customerId">Id của bảng dữ liệu</param>
        /// <returns>Thông tin của 1 đối tượng</returns>
        /// CreatedBy: NXQuang (01/04/2021)
        [HttpGet("{customerId}")]
        public IActionResult Get(Guid customerId)
        {
            // Khởi tạo kết nối tới Database:
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.AMIS";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện lấy dữ liệu từ Database:
            var storeName = $"select * from Employee where EmployeeId = '{customerId}'";
            var customer = dbConnection.Query<Customer>(storeName).FirstOrDefault();
            // Kiểm tra kết quả và trả về cho Client:
            if (customer == null)
                return NoContent();
            else
                return Ok(customer);
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="customer">Khách hàng muốn thêm mới</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exception xảy ra trên Server
        /// </returns>
        /// CreatedBy: NXQuang (01/04/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            // Validate dữ liệu:
            // - check trùng mã:

            // Khởi tạo kết nối tới Database:
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.AMIS";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // Kiểm tra xem có khách hàng nào có mã tương tự hay không?:
            var sqlCheckExitCode = "Select EmployeeCode from Employee Where EmployeeCode = @EmployeeCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EmployeeCode", customer.EmployeeCode);
            var customerExitsCode = dbConnection.Query<string>(sqlCheckExitCode, dynamicParameters);
            if (customerExitsCode.Count() > 0)
            {
                var erroInfo = new
                {
                    devMsg = "EmployeeCode duplucate!",
                    userMsg = "Thông tin mã khách hàng không được phép để trống",
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };

                return BadRequest(erroInfo);
            }
            // Thực hiện lấy dữ liệu từ Database:
            var storeName = "Proc_InsertEmployee";
            var storeParam = customer;
            var rowAffects = dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowAffects == 0)
                return NoContent();
            else
                return Ok(customer);
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng cần chỉnh sửa</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: NXQuang (01/04/2021)
        [HttpPut("{customerId}")]
        public IActionResult Put(Customer customer, Guid customerId)
        {
            // Validate dữ liệu:
            // - check trùng mã:

            // Khởi tạo kết nối tới Database:
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.AMIS";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // Kiểm tra xem có khách hàng nào có mã tương tự hay không?:
            //var sqlCheckExitCode = $"Select CustomerCode from Customer Where CustomerCode = @CustomerCode AND CustomerId <> '{customerId}'";
            //DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@CustomerCode", customer.EmployeeCode);
            //var customerExitsCode = dbConnection.Query<string>(sqlCheckExitCode, dynamicParameters);
            //if (customerExitsCode.Count() > 0)
            //{
            //    var erroInfo = new
            //    {
            //        devMsg = "CustomerCode duplucate!",
            //        userMsg = "Thông tin mã khách hàng không được phép để trống",
            //        errorCode = "misa-001",
            //        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
            //        traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
            //    };

            //    return BadRequest(erroInfo);
            //}
            customer.EmployeeId = customerId;
            // Thực hiện lấy dữ liệu từ Database:

            var storeName = "Proc_UpdateEmployee";
            var storeParam = customer;
            var rowAffects = dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowAffects == 0)
                return NoContent();
            else
                return Ok(customer);
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Khóa chính bảng thông tin khách hàng</param>
        /// <returns>
        ///  - HttpCode: 200 nếu xóa thành công
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: NXQuang (01/04/2021)
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            // Khởi tạo kết nối tới Database:
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.AMIS";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Thực hiện xóa dữ liệu từ Database:
            var storeParam = new
            {
                EmployeeId = customerId
            };
            var rowEffects = dbConnection.Execute("Proc_DeleteEmployeeById", param: storeParam, commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowEffects == 0)
            {
                return NoContent();
            }
            else
                return Ok(rowEffects);
        }
    }
}
