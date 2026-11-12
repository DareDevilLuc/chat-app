import type { Message } from '@/types/message'
import { computed, ref, type Ref } from 'vue'

const messagesAll = ref<Message[]>([])


export function addMessage(newMessage: Message) {
  messagesAll.value.push(newMessage)
}

export async function getMessages(chatId : number) {
  const token = localStorage.getItem('token')

  try{
    const response = await fetch(`http://localhost:5200/api/message/${chatId}`, {
      headers: {
      Authorization: `Bearer ${token}`
    }
    })

    if(!response.ok){
      throw new Error('Failed to fetch messages')
    }

    const messages : Message[] = await response.json()
    return messages
  }
  catch{
    throw new Error('Failed to fetch messages')
  }

}
