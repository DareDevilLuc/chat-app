<script setup lang="ts">

defineProps<{
  selectedID: number
  name: string
}>()

</script>

<template>
  <div class="h-100 d-flex flex-column">
    <!-- header -->
    <div class="p-4 border-bottom bg-secondary" >
      <span class="avatar">
        <img class="avatar-img" src="https://github.com/mdo.png" alt="mdo">
      </span>
      <span class="text-white"> {{ name }} </span>
    </div>

    <div class="flex-grow-1 overflow-auto p-3">

    </div>

    <div class="p-4 border-top bg-secondary">

    </div>
  </div>
</template>

<style scoped>

</style>

