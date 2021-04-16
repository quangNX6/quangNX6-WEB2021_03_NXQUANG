<template>
  <!-- Option sửa/ xóa một nhaan viên-->
  <div id="option-detail" class="small-option" 
  :class="{ isHide: isHide }"
  >
    <button id="btnEdit">Sửa</button>
    <button id="btnDelete">Xóa</button>
  </div>
</template>
<script>
export default {
  props: {
    isHide: Boolean,
    coordinateX : Number,
    coordinateY : Number,
  },
};
</script>
<style scoped>
.isHide {
  display: none;
}
.small-option {
  z-index: 10;
  position: fixed;
  
}
</style>