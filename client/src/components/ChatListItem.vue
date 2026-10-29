<script setup lang="ts">

defineProps<{
  id: number,
  name: string
  selectedId: number
}>()

const emit = defineEmits<{
  select: [{ id: number, name: string }]
}>()

</script>

<template>

  <div class="p-0" :class="id === selectedId ? 'bg-primary' : ''" @click="emit('select', {id: id,
    name: name})">
    <div class="border-bottom border-2 border-danger p-3 d-flex justify-content-center">
      {{ name }}
    </div>
  </div>

</template>
