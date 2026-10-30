export interface Message {
  id: number
  chatId: number,
  senderId: number,
  senderName: string,
  text: string
  createdAt: string
  isOwn: boolean
}
