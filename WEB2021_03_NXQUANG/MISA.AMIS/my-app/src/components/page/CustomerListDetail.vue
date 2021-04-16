<template>
    <div class="m-dialog dialog-detail" id="customer-dialog" >
        <div class="dialog-modal"></div>
        <div class="dialog-content">
            <div class="dialog-header">
                <div class="dialog-header-title">
                    <div class="header-popup flex">
                        <div class="title-popup">Thông tin nhân viên</div>
                        <label class="con-ms-checkbox px-3 px-6" for="isCustomer">
                            <input type="checkbox" id="isCustomer" />
                            <span class="con-slot-label"> Là khách hàng </span>
                        </label>

                        <label class="con-ms-checkbox px-3" for="isSupplier">
                            <input type="checkbox" id="isSupplier" />
                            <span class="con-slot-label"> Là nhà cung cấp </span>
                        </label>
                    </div>
                    <!-- <div class="dialog-header-close" id="btn-close" v-on:click="btnCancelOnClick()">
                        <button>x</button>
                    </div> -->
                </div>
                <div class="ms-popup-close">
                    <div class="con-ms-tooltip">
                        <div class="tooltip-content">
                            <div class="mi mi-24 mi-help mr-6-px help-btn"></div>
                        </div>
                    </div>
                    <div class="con-ms-tooltip">
                        <div class="tooltip-content">
                            <div class="mi mi-24 mi-close" v-on:click="btnCancelOnClick()"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="ms-popup--content popup-h-73">
                <div class="popup-content employee-scroll">
                    <div class="flex pd-b-12">
                        <div class="w-1/2 p-r-26">
                            <div class="flex row-input">
                                <div class="p-r-6">
                                    <div class="flex-text">Mã &nbsp; <span>*</span></div>
                                    <div class="ms-con-input">
                                        <input type="text" 
                                            class="input-code m-input" 
                                            v-model="customerDetail.employeeCode" 
                                            v-on:blur="customerCodeBlur()"
                                            :class= "{ isAlert : isCustomerCodeAlert }"/>
                                    </div>
                                </div>
                                <div class="p-r-6">
                                    <div class="flex-text">Tên &nbsp; <span>*</span></div>
                                    <div class="ms-con-input">
                                        <input type="text" 
                                            class="input-name m-input" 
                                            v-model="customerDetail.employeeName"
                                            v-on:blur="customerNameBlur()"
                                            :class= "{ isAlertName : isCustomerNameAlert }"/>
                                    </div>
                                </div>
                            </div>
                            <div class="flex row-input">
                                <div class="p-r-6">
                                    <div class="flex-text">Đơn vị &nbsp; <span>*</span></div>
                                    <div class="ms-con-input">
                                        <select class="select-name m-input" v-model="customerDetail.departmentId">
                                            <option value="142cb08f-7c31-21fa-8e90-67245e8b283e">Nhân sự</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="flex row-input">
                                <div class="p-r-6">
                                    <div class="flex-text">Chức danh</div>
                                    <div class="ms-con-input">
                                        <input type="text" class="i-title m-input" v-model="customerDetail.employeePosition"/>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!--  -->
                        <div class="w-1/2">
                            <div class="flex row-input-on">
                                <div class="p-r-6">
                                    <div class="flex-text">Ngày sinh</div>
                                    <div class="ms-con-input">
                                        <input type="date" class="i-date m-input" v-model="customerDetail.dateOfBirth"/>
                                    </div>
                                </div>
                                <div class="p-r-6">
                                    <div class="flex-text i-gender">Giới tính</div>
                                    <div class="ms-on">
                                        <input type="radio" name="nam" class="r-check" v-model="customerDetail.gender" value="0"/>
                                        <p>Nam</p>
                                        <input type="radio" name="nam" class="r-check" v-model="customerDetail.gender" value="1"/>
                                        <p>Nữ</p>
                                    </div>
                                </div>
                            </div>
                            <div class="flex row-input-on">
                                <div class="p-r-6">
                                    <div class="flex-text">Số CMND</div>
                                    <div class="ms-con-input">
                                        <input type="text" class="input-identyti m-input" v-model="customerDetail.identityNumber"/>
                                    </div>
                                </div>
                                <div class="p-r-7">
                                    <div class="flex-text">Ngày cấp </div>
                                    <div class="ms-con-input">
                                        <input type="date" class="i-date m-input" v-model="customerDetail.identityDate"/>
                                    </div>
                                </div>
                            </div>
                            <div class="flex row-input-on">
                                <div class="p-r-8">
                                    <div class="flex-text">Nơi cấp</div>
                                    <div class="ms-con-input">
                                        <input type="text" class="i-address m-input" v-model="customerDetail.identityPlace"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--  -->

                <div class="dialog-bottom">
                    <Tabs>
                        <Tab title="Liên hệ">
                            <div class="tab-list">
                                <div class="tab-list-address">
                                    <div class="t-text">Địa chỉ</div>
                                    <div class="ms-con-input">
                                        <input type="text" class="t-address m-input" v-model="customerDetail.address"/>
                                    </div>
                                </div>
                                <div class="flex row-input-on">
                                    <div class="p-r-9">
                                        <div class="flex-text">ĐT di động </div>
                                        <div class="ms-con-input">
                                            <input type="text" class="input-phone m-input" v-model="customerDetail.phoneNumber"/>
                                        </div>
                                    </div>
                                    <div class="p-r-9">
                                        <div class="flex-text">ĐT cố định </div>
                                        <div class="ms-con-input">
                                            <input type="text" class="input-phone m-input" v-model="customerDetail.telephoneNumber"/>
                                        </div>
                                    </div>
                                    <div class="p-r-9">
                                        <div class="flex-text">Email </div>
                                        <div class="ms-con-input">
                                            <input type="text" class="input-phone m-input" v-model="customerDetail.email"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </Tab>
                        <Tab title="Tài khoản ngân hàng">
                            
                        </Tab>
                    </Tabs>
                </div>
                <div class="divide"></div>
            </div>

            <div class="dialog-footer">
                <button class="btn-cancel" v-on:click="btnCancelOnClick()">
                    <div class="btn-text">Hủy</div>
                </button>
                <button class="btn-save" id="btn-save" type="submit" @click="btnSaveOnClick()" >
                    <div class="btn-text" >Cất</div>
                </button>
                <button class="btn-save-cus" id="btn-save" type="submit" @click="btnSaveOnClick()" >
                    <div class="btn-text" >Cất và Thêm</div>
                </button>
            </div>

            <!-- <div class="dialog-body">
                <div class="d-avatar">
                    <div class="cus-avatar">
                        <img src="../../assets/img/default-avatar.jpg" />
                        <div>Chọn ảnh</div>
                    </div>
                    <div class="customer-add-id">
                        <div class="customer-add-code">
                            <p>Mã khách hàng</p>
                            <input type="text" 
                            id="CustomerCode" 
                            fileName="f-CustomerCode" 
                            v-model="customerDetail.customerCode"
                            v-on:blur="customerCodeBlur()"
                            :class= "{ isAlert : isCustomerCodeAlert }"
                            />
                        </div>
                        <div class="customer-add-card">
                            <p>Mã thẻ thành viên</p>
                            <input type="text" id="CustomerId" fileName="f-CustomerId" v-model="customerDetail.memberCardCode"/>
                        </div>
                        <div class="customer-add-date">
                            <p>Ngày sinh</p>
                            <input type="date" id="Birthday" fileName="f-Birthday" v-model="customerDetail.dateOfBirth"/>
                        </div>
                    </div>

                    <div class="customer-add-person">
                        <div class="customer-add-name">
                            <p>Họ tên</p>
                            <input type="text" 
                            ref="fullName"
                            id="FullName" 
                            fileName="f-FullName" 
                            v-model="customerDetail.fullName"
                            v-on:blur="customerNameBlur()"
                            :class= "{ isAlertName : isCustomerNameAlert }">
                        </div>
                        <div class="customer-add-group">
                            <p>Nhóm khách hàng</p>
                            <select id="Ranking" fileName="f-CustomerGroupId" v-model="customerGroup.customerGroupId" >
                                <option v-for="(cusGroup, index) in CustomerGroups" :key="index">{{cusGroup.CustomerGroups}}</option>
                                <option>Vàng</option>
                            </select>
                        </div>
                        <div class="customer-add-gender">
                            <p>Giới tính</p>
                            <div id="Gender">
                                <input type="radio" name="nam" v-model="customerDetail.gender" value="1" /> Nam
                                <input type="radio" name="nam" v-model="customerDetail.gender" value="0"/> Nữ
                                <input type="radio" name="nam" v-model="customerDetail.gender" value="3"/> Khác
                            </div>
                        </div>
                    </div>
                </div>
                <div class="customer-add-email-phone">
                    <div class="add-email">
                        <p>Email</p>
                        <input type="email" id="Email" fileName="f-Email" v-model="customerDetail.email"
                            v-on:blur="customerEmailBlur()"
                            :class= "{ isAlertEmail: isCustomerEmailAlert }"/>
                        <p>Tên công ty</p>
                        <input type="text" id="NameCompany" fileName="f-NameCompany" v-model="customerDetail.NameCompany" />
                    </div>
                    <div class="add-phone">
                        <p>Số điện thoại</p>
                        <input type="text" id="PhoneNumber" fileName="f-PhoneNumber" v-model="customerDetail.phoneNumber" 
                        v-on:blur="customerPhoneBlur()"
                            :class= "{ isAlertPhone: isCustomerPhoneAlert }"/>
                        <p>Mã số thuế</p>
                        <input type="text" fileName="f-CompanyTaxCode" v-model="customerDetail.CompanyTaxCode" />
                    </div>
                </div>
                <div style="clear:both;"></div>
                <div class="customer-add-address">
                    <div class="add-address">
                        <p>Địa chỉ</p>
                        <input type="text" id="Address" filename="f-Address" v-model="customerDetail.address"/>
                    </div>
                </div>
            </div> -->
            
        </div>
    </div>
    
</template>
<style>
@import "../../css/dialog.css";
.isAlert, .isAlertName, .isAlertEmail, .isAlertPhone{
    border: 1px solid red;
}

</style>

<script>
import axios from 'axios'
import { Tabs, Tab } from 'vue-slim-tabs'
export default {
    components:{
        Tabs,
        Tab
    },
   props: {
        customerDetail: {type: Object, default: null},
        formMode:{type: String, default:"add"},
        isCustomerCodeAlert : Boolean,
        isCustomerNameAlert : Boolean,
        isCustomerEmailAlert: Boolean,
        isCustomerPhoneAlert: Boolean,

   },
   data(){
       return{
            customerGroup: {
                customerGroupId: "3631011e-4559-4ad8-b0ad-cb989f2177da"
            },
            customer :{},
            // isCustomerCode : true,
       }
   },
   methods:{
       /**
        * Gọi đến phương thức ẩn Dialog của cha
        * CreatedBy: NXQuang (9/4/21)
        */
        btnCancelOnClick: function() {
            this.$emit('hideDialog');
        },
        btnSaveOnClick(){
            console.log(this.formMode)
            if(this.formMode =='add'){
                axios.post('https://localhost:44343/api/v1/Customers', this.customerDetail)
                .then(res => {
                    console.log(res);
                    this.$emit('hideDialog');
                }).catch(res => {
                    console.log(res);
                })
                console.log(this.customerDetail);
            }
            else{
                axios.put('https://localhost:44343/api/v1/Customers/' + this.customerDetail.employeeId, this.customerDetail)
                .then(res => {
                    console.log(res);
                    this.$emit('hideDialog');
                }).catch(res => {
                    console.log(res);
                });
                
            }
        },
        // bắt sự kiên On Blur
        customerCodeBlur(){
            // alert("Customer Blur!!");
            if(!this.customerDetail.employeeCode){
                this.isCustomerCodeAlert = true
            } else this.isCustomerCodeAlert = false
        },
        customerNameBlur(){
            if(!this.customerDetail.employeeName){
                this.isCustomerNameAlert = true
            } else this.isCustomerNameAlert = false
        },
        customerEmailBlur(){
            if(!this.customerDetail.email){
                this.isCustomerEmailAlert = true
            } else this.isCustomerEmailAlert = false
        },
        customerPhoneBlur(){
            if(!this.customerDetail.phoneNumber){
                this.isCustomerPhoneAlert = true
            } else this.isCustomerPhoneAlert = false
        },
        //Validate onSaveButtonClick
        validate(){
            alert("Validate!")
            if(!this.customerDetail.fullName){
                this.isCustomerNameAlert = true
                this.$refs.fullName.focus();
            } else this.isCustomerNameAlert = false
            alert("save!")
        }
   },
}
//checkbox
   
</script>