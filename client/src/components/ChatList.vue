<script setup lang="ts">
import { getChats } from '@/composables/useChats';
import ChatListItem from './ChatListItem.vue';
import { ref, onMounted } from 'vue';
import type { Chat } from '@/types/chat';

const chats = ref<Chat[]>([])

onMounted(async () => {
  chats.value = await getChats()
})

defineProps<{
  selectedId: number
}>()

const emits = defineEmits<{
  select: [{id: number, name: string}]
}>()

</script>

<template>

  <span v-if="chats.length == 0" class="p-3">You have no recent messages!</span>
  <div v-else>
    <ChatListItem
        v-for="chat in chats"
        :key = "chat.id"
        :id = "chat.id"
        :name="chat.name"
        :selectedId = "selectedId"
        @select="emits('select', $event)"
        />
  </div>

</template>

<style scoped>

</style>

