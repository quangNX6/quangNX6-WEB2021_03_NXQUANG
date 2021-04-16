<template>
    <div class="m-dialog-delete delete-hide">
        <div class="d-modal"></div>
        <div class="d-content">
            <div class="d-main">
                <div class="md-top">
                    <div class="md-top-icon w-icon"></div>
                    <div class="md-top-title">
                        Bạn có thực sự muốn xóa Nhân Viên &#60;NV4543&#62; <br>
                        không ?
                    </div>
                </div>
                <div class="md-bottom">
                    <div class="b-word-delete">
                        <div class="b-w-cancel">
                            <button class="btn-w-cancel" v-on:click="btnNoOnclick()">Không</button>
                        </div>
                        <div class="b-w-cancel">
                            <button class="btn-w-yes" v-on:click="btnDeleteClick()">Có</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<style >
@import "../../css/delete.css";
</style>
<script>
export default {
    data(){
        return {

        }
    },
    methods:{
        /**
         * Gọi đến hàm ẩn của cha
         * createdBy: NXQuang 16/4/21
         */
        btnNoOnclick: function() {
            this.$emit('hideDelete');
        },
        btnDeleteClick(){
            this.$emit('deleteData');
        }
    },
}
</script>
