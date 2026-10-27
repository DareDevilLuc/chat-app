<script setup lang="ts">

defineProps<{
  id: number,
  name: string
}>()

</script>

<template>

  <div class="p-0">
    <div class="border-bottom border-2 border-danger p-3 d-flex justify-content-center">
      {{ name }}
    </div>
  </div>

</template>
