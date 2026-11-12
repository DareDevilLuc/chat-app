import type { Chat } from "@/types/chat";
import { ref } from "vue";


export async function getChats(){
  const token = localStorage.getItem('token')

  const response = await fetch(`http://localhost:5200/api/chat`, {
  headers: {
    Authorization: `Bearer ${token}`
  }
  })

  if(!response.ok) {
    throw new Error("Failed to retrieve chat")
  }

  const chats: Chat[] = await response.json()

  console.log(chats)

  return chats
}
