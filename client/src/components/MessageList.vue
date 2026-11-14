<script setup lang="ts">
import type { Message } from '@/types/message.ts'
import MessageItem from './MessageItem.vue';

const props = defineProps<{
  messages: Message[]
}>()
</script>

<template>
  <div class="d-flex flex-column gap-1">
    <MessageItem v-for="(message, index) in messages" :key="message.id" :message="message"
    :show_name="index === 0 || messages[index-1]?.senderId !== message.senderId"/>
  </div>
</template>

<style scoped>

</style>

