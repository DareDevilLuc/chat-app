<script setup lang="ts">
import type { Message } from '@/types/message.ts'

defineProps<{
  message: Message,
  isOwn: boolean
}>()

</script>

<template>
  <div class="d-flex flex-column" :class="{ 'align-items-start': !isOwn, 'align-items-end' : isOwn  }">
    <div>
      {{ message.senderName }}
    </div>
    <div :class="isOwn ? 'your-message' : 'their-message'">
      {{ message.text }}
    </div>
  </div>
</template>

<style scoped>
.their-message {
  background-color: lightgray;
  color: black;
  padding: 0.5rem;
  border-radius: 8px;
}

.your-message {
  background-color: #2a54f8;
  color: white;
  padding: 0.5rem;
  border-radius: 8px;
}

</style>
