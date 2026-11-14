<script setup lang="ts">
import type { Message } from '@/types/message.ts'

defineProps<{
  message: Message,
  show_name: boolean
}>()

function formatTimestamp(date : String) {
  return new Date(date.replace(' ', 'T')).toLocaleTimeString([], {
    hour: '2-digit',
    minute: '2-digit'
  })
}

</script>

<template>
  <div class="d-flex flex-column" :class="{ 'align-items-start': !message.isOwn, 'align-items-end' :
    message.isOwn  }" :title="formatTimestamp(message.createdAt)">
    <div v-if="show_name" class="pl-2">
      {{ message.senderName }}
    </div>
    <div :class="message.isOwn ? 'your-message' : 'their-message'">
      {{ message.text }}
    </div>
  </div>
</template>

<style scoped>
.their-message {
  background-color: lightgray;
  color: black;
  padding: 0.5rem;
  border-radius: 16px;
}

.your-message {
  background-color: #2a54f8;
  color: white;
  padding: 0.5rem;
  border-radius: 16px;
}

</style>
