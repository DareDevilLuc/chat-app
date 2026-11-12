<script setup lang="ts">
import { nextTick, onMounted, ref, toRef, watch, } from 'vue';
import MessageInput from './MessageInput.vue';
import MessageList from './MessageList.vue';
import { getMessages, addMessage } from '@/composables/useMessages';
import type { Message } from '@/types/message';


const props = defineProps<{
  selectedID: number
  name: string
}>()

const messages = ref<Message[]>([])

onMounted(async () => {
  messages.value = await getMessages(props.selectedID)
})

function sendNewMessage(text: string) {
  if(text === '') return

  const newMessage = {
    id: 11,
    chatId: props.selectedID,
    senderId: 1,
    senderName: "You",
    text: text,
    createdAt: "2026-11-01 10:33",
    isOwn: true
  }

  addMessage(newMessage)
}

const messagesContainer = ref<HTMLElement | null>(null)

async function scrollToBottom() {
  await nextTick()

  if(messagesContainer.value) {
  messagesContainer.value.scrollTop = messagesContainer.value.scrollHeight
  }
}

watch(() => messages.value.length, () => { scrollToBottom() },  { immediate: true })


</script>

<template>
  <div class="h-100 d-flex flex-column">
    <!-- header -->
    <div class="d-flex p-4 border-bottom bg-secondary lh-1 align-items-center">
      <v-avatar image="https://github.com/mdo.png" size="50" class="me-2" />
      <span class="text-white fs-3"> {{ props.name }} </span>
    </div>

    <div class="flex-grow-1 overflow-auto p-3" ref="messagesContainer">
      <MessageList :messages="messages" />
    </div>

    <div class="p-4 border-top bg-secondary">
      <MessageInput @send="sendNewMessage($event)"/>
    </div>
  </div>
</template>

<style scoped></style>
