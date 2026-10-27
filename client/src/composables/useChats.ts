import type { Chat } from "@/types/chat";
import { ref } from "vue";

export function useChats(){
  const chats = ref<Chat[]>([
    { id: 1, name: "Bryan" },
    { id: 2, name: "Cole" },
    { id: 3, name: "Kyle" },
  ])

  return { chats }
}
