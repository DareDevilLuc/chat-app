<script setup lang="ts">
import { ref } from 'vue';
import ChatList from '@/components/ChatList.vue';
import ChatWindow from '@/components/ChatWindow.vue';

const selectedId = ref()

selectedId.value = 0

</script>

<template>

  <div class="container-fluid">
    <div class="row min-vh-100">
      <div class="col-3 bg-dark text-white p-0">
        <ChatList :selectedId="selectedId" @select="selectedId = $event"/>
      </div>

      <div class="col-9 d-flex align-items-center justify-content-center">
        <ChatWindow
        v-if="selectedId != 0"
        :selectedID="selectedId"/>
        <p v-else>Select a chat to view!</p>
      </div>
    </div>
  </div>

</template>

