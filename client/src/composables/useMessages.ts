import type { Message } from '@/types/message'
import { computed, ref, type Ref } from 'vue'

export function useMessages(chatId: Ref<number>) {
  const messagesAll = ref<Message[]>([])

  messagesAll.value = [
    {
      id: 1,
      chatId: 1,
      senderId: 2,
      senderName: "Bryan",
      text: "Hey, you coming to the thing tonight?",
      createdAt: "2026-10-30T18:30:00.000Z",
      isOwn: false
    },
    {
      id: 2,
      chatId: 1,
      senderId: 1,
      senderName: "You",
      text: "Yeah! What time are we meeting?",
      createdAt: "2026-10-30T18:32:00.000Z",
      isOwn: true
    },
    {
      id: 3,
      chatId: 1,
      senderId: 2,
      senderName: "Bryan",
      text: "Around 7:30 PM. We're meeting at the usual spot.",
      createdAt: "2026-10-30T18:33:00.000Z",
      isOwn: false
    },
    {
      id: 4,
      chatId: 1,
      senderId: 1,
      senderName: "You",
      text: "Got it. I'll be there!",
      createdAt: "2026-10-30T18:35:00.000Z",
      isOwn: true
    },
    {
      id: 5,
      chatId: 1,
      senderId: 3,
      senderName: "Alex",
      text: "Don't forget to bring the documents tomorrow.",
      createdAt: "2026-10-30T18:40:00.000Z",
      isOwn: false
    },
    {
      id: 6,
      chatId: 1,
      senderId: 1,
      senderName: "You",
      text: "Thanks for reminding me. I almost forgot 😂",
      createdAt: "2026-10-30T18:42:00.000Z",
      isOwn: true
    },
    {
      id: 7,
      chatId: 1,
      senderId: 2,
      senderName: "Bryan",
      text: "Also, did you finish the project?",
      createdAt: "2026-10-30T18:45:00.000Z",
      isOwn: false
    },
    {
      id: 8,
      chatId: 1,
      senderId: 1,
      senderName: "You",
      text: "Almost done. Just fixing a few bugs.",
      createdAt: "2026-10-30T18:47:00.000Z",
      isOwn: true
    },
    {
      id: 9,
      chatId: 1,
      senderId: 2,
      senderName: "Bryan",
      text: "Nice! Let me know when it's ready.",
      createdAt: "2026-10-30T18:50:00.000Z",
      isOwn: false
    },
    {
      id: 10,
      chatId: 1,
      senderId: 1,
      senderName: "You",
      text: "Will do. See you later!",
      createdAt: "2026-10-30T18:52:00.000Z",
      isOwn: true
    },
  ]

  const messages = computed(() =>
    messagesAll.value.filter(m => m.chatId === chatId.value))

  return { messages }
}
