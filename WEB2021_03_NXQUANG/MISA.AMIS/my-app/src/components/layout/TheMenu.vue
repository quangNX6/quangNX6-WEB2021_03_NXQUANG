<template>
    <div class="sidebar">
        <div class="logo-site">
            <div class="logo-toggle mt-12" title="Thu gọn sidebar"></div>
            <div class="logo-icon mt-12" title="Trang chủ"></div>
        </div>
        <div class="sidebar-content">
            <router-link class="item" to="/report">
                <div class="item-icon icon-overview"></div>
                <a href="#" class="item-text">Tổng quan</a>
            </router-link>
            <router-link class="item" to="/customer">
                <div class="item-icon icon-customer"></div>
                <a href="#" class="item-text">Nhân viên</a>
            </router-link>
            <router-link class="item" to="/report">
                <div class="item-icon icon-money"></div>
                <a href="#" class="item-text">Tiền gửi</a>
            </router-link>
            <!-- <div class="item">
                <div class="item-icon icon-liststaff"></div>
                <a href="#" class="item-text">Danh sách khách hàng</a>
            </div> -->
            <!-- <router-link class="item" to="/customer">
                <div class="item-icon icon-liststaff"></div>
                <a href="#" class="item-text">Danh sách khách hàng</a>
            </router-link> -->
            <router-link class="item" to="/report">
                <div class="item-icon icon-buy"></div>
                <a href="#" class="item-text">Mua hàng</a>
            </router-link>
            <router-link class="item" to="/report">
                <div class="item-icon icon-sell"></div>
                <a href="#" class="item-text">Bán hàng</a>
            </router-link>
            <router-link class="item" to="/report">
                <div class="item-icon icon-warehouse"></div>
                <a href="#" class="item-text">Kho</a>
            </router-link>
            <router-link class="item" to="/report">
                <div class="item-icon icon-tools"></div>
                <a href="#" class="item-text">Công cụ dụng cụ</a>
            </router-link>
            <router-link class="item" to="/report">
                <div class="item-icon icon-tax"></div>
                <a href="#" class="item-text">Thuế</a>
            </router-link>
            <router-link class="item" to="/report">
                <div class="item-icon icon-general"></div>
                <a href="#" class="item-text">Tổng hợp</a>
            </router-link>
            <router-link class="item" to="/report">
                <div class="item-icon icon-report"></div>
                <a href="#" class="item-text">Báo cáo</a>
            </router-link>

        </div>
    </div>
    
</template>
<style scoped>

</style>