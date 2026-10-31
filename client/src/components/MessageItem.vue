<script setup lang="ts">
import type { Message } from '@/types/message.ts'

defineProps<{
  message: Message,
  isOwn: boolean
}>()

</script>

<template>
  <div class="d-flex flex-column mb-3">
    <div>
      From: {{ message.senderName }}
    </div>
    <div>
      Message: {{ message.text }}
    </div>
  </div>
</template>

<style scoped></style>
