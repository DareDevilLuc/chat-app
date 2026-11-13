<script setup lang="ts">
import { nextTick, onMounted, ref, watch, onUnmounted } from 'vue';
import MessageInput from './MessageInput.vue';
import MessageList from './MessageList.vue';
import { getMessages } from '@/composables/useMessages';
import type { Message } from '@/types/message';
import {
  connection,
  startConnection,
  joinChat,
  leaveChat
} from '@/services/signalr'


const props = defineProps<{
  selectedID: number
  name: string
}>()

const messages = ref<Message[]>([])

function handleReceiveMessage(message: Message) {
   const currentUserId = localStorage.getItem('userId')

   message.isOwn = message.senderId == Number(currentUserId)
   messages.value.push(message)
}

onMounted(async () => {
  messages.value = await getMessages(props.selectedID)

  connection.on('ReceiveMessage', handleReceiveMessage)

  await startConnection()

  await joinChat(props.selectedID)

})

onUnmounted(async () => {
  connection.off('ReceiveMessage', handleReceiveMessage)
  await leaveChat(props.selectedID)
})

watch(
  () => props.selectedID, async (newId, oldId) => {
    await leaveChat(oldId)
    await joinChat(newId)
    messages.value = await getMessages(newId)
  }
)

async function sendNewMessage(text: string) {
  if(text === '') return

  const newMessage = {
    chatId: props.selectedID,
    content: text
  }

  try {
   const response = await fetch('http://localhost:5200/api/message', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${localStorage.getItem('token')}`
    },
    body: JSON.stringify(newMessage)
   })

   if(!response.ok){
    throw new Error('Error sending message')
   }

  }
  catch{
    throw new Error('Error sending message')
  }


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
