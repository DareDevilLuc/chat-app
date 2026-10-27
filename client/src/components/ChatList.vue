<script setup lang="ts">
import { useChats } from '@/composables/useChats';
import ChatListItem from './ChatListItem.vue';

const { chats } = useChats()

</script>

<template>

  <span v-if="chats.length == 0" class="p-3">You have no recent messages!</span>
  <div v-else>
    <ChatListItem
        v-for="chat in chats"
        :key = "chat.id"
        :id = "chat.id"
        :name="chat.name"
        />
  </div>

</template>

<style scoped>

</style>

