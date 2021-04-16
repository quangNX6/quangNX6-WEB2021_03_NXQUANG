<template>
  <div v-on:click="closeOption">
    <SmallOption
      :isHide="isHideOption"
      id="small-option"
     
    />
    <CustomerListDetail
      :formMode="dialogFormMode"
      :customerDetail="selectedCustomer"
      @hideDialog="hideDialog"
      v-if="isHideParsent"
    />
    <DeleteEmployee @hideDelete="hideDelete" v-if="ishideStart" :employeeDelete="selectDelete"
     @deleteData="deleteCustomer"/>
    <div class="header-content"  >
      <div class="header-title">Nhân viên</div>
      <div class="header-button">
        <button class="btn-add m-btn" id="btn-add-cus" @click="btnOnClick()">
          <div class="btn-text" id="btn-add-cus">Thêm</div>
        </button>
      </div>
    </div>
    <div class="category">
      <div class="svg-icon category-left"></div>
      <a>Tất cả danh mục</a>
    </div>
    <div class="tool-bar">
      <div class="tool-bar-left">
        <input
          type="text"
          class="icon-search input-search icon-x m-input"
          placeholder="Tìm kiếm theo mã, tên nhân viên"
        />
      </div>
    </div>
    <div class="grid list_customer">
      <table
        class="fixed_headers table"
        id="tbl-customer"
        width="100%"
        cellspacing="0"
        cellpadding="0"
      >
        <thead>
          <tr>
            <th>MÃ NHÂN VIÊN</th>
            <th>TÊN NHÂN VIÊN</th>
            <th>CHỨC DANH</th>
            <th>TÊN ĐƠN VỊ</th>
            <th>SỐ TÀI KHOẢN</th>
            <th>TÊN NGÂN HÀNG</th>
            <th>TRẠNG THÁI</th>
            <th>CHI NHÁNH</th>
            <th>CHỨC NĂNG</th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="customer in customers"
            :key="customer.EmployeeId"
            @dblclick="trOnClick(customer.employeeId)"
          >
            <td>{{ customer.employeeCode }}</td>
            <td>{{ customer.employeeName }}</td>
            <td>{{ customer.employeePosition }}</td>
            <td>{{ customer.departmentId }}</td>
            <td>{{ customer.bankAccountNumber }}</td>
            <td>{{ customer.bankName }}</td>
            <td>{{  }}</td>
            <td>{{ customer.bankBranchName }}
            <td>
              <!-- <button
                title="xóa"
                type="button"
                @click="deleteCustomer(customer.customerId)"
              >
                Xóa
              </button> -->
              <div class="btn-event">
                  <div class="btn-edit-cutomer" @click="trOnClick(customer.employeeId)">Sửa</div>
                  <div class="btn-work btn-work-icon" @click="showFunctionMenu($event,customer.employeeId)"></div>
              </div>
              <div
                  class="data-more-action"
                  v-if="showMenu"
                  :style="{ top: menuTop, right: menuRight }">
                  <div class="action-list">Nhân bản</div>
                  <div class="action-list" @click="onDelete()" >Xóa</div>
                  <div class="action-list">Ngừng sử dụng</div>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="pagination">
      <div class="text-left">Tổng số: <b>100</b> Bản ghi</div>
      <div class="paging">
        <div class="btn-first-page btn-paging">Trước </div>
        <div class="page-number">
          <div class="p-number p-active">1</div>
          <div class="p-number">2</div>
          <div class="p-number">3</div>
          <div class="p-number">4</div>
        </div>
        
        <div class="btn-last-page btn-paging">Sau</div>
      </div>
      <div class="text-right">
        <p>20 bản ghi trên 1 trang</p>
        <div class="m-icon-updown"></div>
      </div>
    </div>
    <!-- <div
        class="data-more-action"
        v-if="showMenu"
        :style="{ top: menuTop, right: menuRight }">
        <div class="action-list">Nhân bản</div>
        <div class="action-list"  @click="deleteCustomer(customer.employeeId)">Xóa</div>
        <div class="action-list">Ngừng sử dụng</div>
    </div> -->
    
  </div>
</template>
<script>
import CustomerListDetail from "./CustomerListDetail.vue";
import DeleteEmployee from "./DeleteEmployee.vue";
import axios from "axios";

import SmallOption from "../sub_item/SmallOption.vue";

export default {
  name: "App",
  components: {
    CustomerListDetail,
    DeleteEmployee,
    SmallOption,
  },
  data() {
    return {
      isHideOption: true,
      dialogFormMode: "add",
      isHideParsent: false,
      ishideStart: false,
      customers: [],
      selectedCustomer: {},
      selectDelete:{},
      showMenu:false,
      employeeId: ""
    };
  },
  created() {
    // load dữ liệu
    /**
     * Hiển thị dữ liệu từ Api
     */
    axios
      .get("https://localhost:44343/api/v1/Customers")
      .then((res) => {
        this.customers = res.data;
        console.log(res);
      })
      .catch((res) => {
        console.log(res);
      });
  },
  props: [],
  methods: {
    // load lại dữ liệu trang khi thêm hoặc sửa
    loadData() {
      axios
        .get("https://localhost:44343/api/v1/Customers")
        .then((res) => {
          this.customers = res.data;
          console.log(res);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    hideDialog() {
      this.isHideParsent = false;
      this.loadData();
    },
    hideDelete(){
      this.ishideStart = false;
      this.loadData();
    },
    /**
     * Gọi đến phương thức hiển thị Dialog
     * CreatedBy: NXQuang (9/4/21)
     */
    btnOnClick: function () {
      this.isHideParsent = true;
      this.selectedCustomer = {};
    },
    /**
     * Gọi đến form xác nhận xóa
     * CreatedBy: NXQuang (9/4/21)
     */
    
    onDelete(id){
      this.ishideStart = true;
      this.selectDelete = id;
      this.showMenu = false;
    },
    /**
     * Lấy ra thông tin khách hàng
     * CreatedBy : NXQuang(9/4/21)
     */
    trOnClick(employeeId) {
      // Lấy ID của bản ghi được chọn

      // Gọi đến API lấy thông tin của khách hàng
      axios
        .get("https://localhost:44343/api/v1/Customers/" + employeeId)
        .then((res) => {
          this.selectedCustomer = res.data;
          console.log(res);
        })
        .catch((res) => {
          console.log(res);
        });
      // Cập nhật trạng thái Form
      this.dialogFormMode = "edit";
      // Hiển thị Dialog chị tiết
      this.isHideParsent = true;
    },

    /**
     * Xóa khách hàng
     * CreatedBy : NXQuang(9/4/21)
     */
    deleteCustomer(value) {
      console.log(this.employeeId)
      axios.delete(`https://localhost:44343/api/v1/Customers/` + this.employeeId)
      .then(() => {
          this.ishideStart = value;
          this.loadData();
      })
      .catch()
    },
    closeOption() {
      this.isHideOption = true;
    },
    showFunctionMenu(e,employeeId){
        this.showMenu = !this.showMenu;
        var menuPosition = e.currentTarget.getBoundingClientRect();
        this.menuTop = `${menuPosition.top + 20}px`;
        this.menuRight = `${window.innerWidth - menuPosition.right -10}px`;
        console.log(e.target);
        this.employeeId = employeeId;
    },
  },
};
</script>
<style>
@import "../../css/content.css";
@import "../../css/main.css";
</style>

