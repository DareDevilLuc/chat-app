<script setup lang="ts">
import type { Message } from '@/types/message.ts'
import MessageItem from './MessageItem.vue';

const props = defineProps<{
  messages: Message[]
}>()
</script>

<template>
  <div class="d-flex flex-column">
    <MessageItem v-for="message in messages" :key="message.id" :message="message"/>
  </div>
</template>

<style scoped>

</style>

