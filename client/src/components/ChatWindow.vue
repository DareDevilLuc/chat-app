<script setup lang="ts">

defineProps<{
  selectedID: number
  name: string
}>()

</script>

<template>
  <!-- header -->
  <div>
    {{ name }}
  </div>
</template>

<style scoped>

</style>

