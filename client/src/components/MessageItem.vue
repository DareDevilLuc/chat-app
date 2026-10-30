<script setup lang="ts">
import type { Message } from '@/types/message.ts'

defineProps<{
  message: Message,
}>()

</script>

<template>
  <div>
    From: {{ message.senderName }} | To: {{ message.chatId }}
  </div>
</template>

<style scoped></style>
