<template>
  <div id="app">
    <div class="main">
        <TheMenu/>
        <div class="contain">
            <TheHeader/>
            <TheContent/>
        </div>
    </div>
  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue'
import TheMenu from './components/layout/TheMenu.vue'
import TheContent from './components/layout/TheContent.vue'


export default {
 name: 'App',
 components:{
   TheHeader,
   TheMenu,
   TheContent
 }
  
}
</script>

<style>
@import "./css/button.css";
@import "./css/common.css";
@import "./css/content.css";
@import "./css/dialog.css";
@import "./css/header.css";
@import "./css/main.css";
@import "./css/pagination.css";
@import "./css/sidebar.css";
</style>
