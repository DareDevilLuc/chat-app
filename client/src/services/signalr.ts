import * as signalR from '@microsoft/signalr'

const connection = new signalR.HubConnectionBuilder()
  .withUrl('http://localhost:5200/chathub')
  .withAutomaticReconnect()
  .build()

export async function startConnection() {
  try {
    if (connection.state === signalR.HubConnectionState.Disconnected) {
      await connection.start()
      console.log('Connected to SignalR')
    }
  } catch (error) {
    console.error('SignalR connection failed:', error)
  }
}

export async function joinChat(chatId: number) {
  if (connection.state === signalR.HubConnectionState.Connected) {
    await connection.invoke('JoinChat', chatId)
  }
}

export async function leaveChat(chatId: number) {
  if (connection.state === signalR.HubConnectionState.Connected) {
    await connection.invoke('LeaveChat', chatId)
  }
}

export { connection }
