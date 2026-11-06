import type { Message } from '@/types/message'
import { computed, ref, type Ref } from 'vue'

const messagesAll = ref<Message[]>([])

messagesAll.value

export function addMessage(newMessage: Message) {
  messagesAll.value.push(newMessage)
}

export function useMessages(chatId: Ref<number>) {
  const messages = computed(() =>
    messagesAll.value.filter(m => m.chatId === chatId.value))


  return { messages }
}
