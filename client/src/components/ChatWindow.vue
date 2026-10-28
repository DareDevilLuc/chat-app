<script setup lang="ts">

defineProps<{
  selectedID: number
}>()

</script>

<template>
  <div>
    You chose id: {{ selectedID }}
  </div>
</template>

<style scoped>

</style>

