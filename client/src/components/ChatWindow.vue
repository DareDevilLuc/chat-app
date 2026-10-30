<script setup lang="ts">
import { ref, toRef, watch, watchEffect } from 'vue';
import MessageInput from './MessageInput.vue';
import MessageList from './MessageList.vue';
import type { Message } from '@/types/message.ts'
import { useMessages } from '@/composables/useMessages';


const props = defineProps<{
  selectedID: number
  name: string
}>()

const { messages } = useMessages(toRef(props, 'selectedID'))

watch(messages, (newMessages) => console.log(newMessages), {deep: true, immediate: true })

</script>

<template>
  <div class="h-100 d-flex flex-column">
    <!-- header -->
    <div class="d-flex p-4 border-bottom bg-secondary lh-1 align-items-center" >
      <v-avatar image="https://github.com/mdo.png" size="50" class="me-2"/>
      <span class="text-white fs-3"> {{ props.name }} </span>
    </div>

    <div class="flex-grow-1 overflow-auto p-3">
      <MessageList/>
    </div>

    <div class="p-4 border-top bg-secondary">
      <MessageInput/>
    </div>
  </div>
</template>

<style scoped>

</style>
