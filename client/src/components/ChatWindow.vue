<script setup lang="ts">

defineProps<{
  selectedID: number
  name: string
}>()

</script>

<template>
  <div class="h-100 d-flex flex-column">
    <!-- header -->
    <div class="d-flex p-4 border-bottom bg-secondary lh-1 align-items-center" >
      <span class="align-items-center me-2">
        <img class="rounded-circle" src="https://github.com/mdo.png" alt="mdo" width="40" height="40">
      </span>
      <span class="text-white fs-3"> {{ name }} </span>
    </div>

    <div class="flex-grow-1 overflow-auto p-3">

    </div>

    <div class="p-4 border-top bg-secondary">

    </div>
  </div>
</template>

<style scoped>

</style>

