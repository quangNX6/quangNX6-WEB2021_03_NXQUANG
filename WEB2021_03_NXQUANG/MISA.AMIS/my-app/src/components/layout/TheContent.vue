<template>
    <div class="content">
        <!-- <CustomerList /> -->
        <router-view></router-view>
    </div>
</template>
<script>
// import CustomerList from '../page/CustomerList.vue'


export default {
 name: 'App',
 components:{
  //  CustomerList
 }
  
}
</script>
<style>
@import "../../css/content.css";
</style>