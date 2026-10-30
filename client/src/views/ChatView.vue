<script setup lang="ts">
import { ref, watch } from 'vue';
import ChatList from '@/components/ChatList.vue';
import ChatWindow from '@/components/ChatWindow.vue';

const selectedId = ref()
const selectedName = ref()

selectedId.value = 0

function handleSelect(event: {id: number, name: string}){
  selectedId.value = event.id
  selectedName.value = event.name
}

</script>

<template>

  <div class="container-fluid">
    <div class="row min-vh-100">
      <div class="col-3 bg-dark text-white p-0">
        <ChatList :selectedId="selectedId" @select="handleSelect"/>
      </div>

      <div class="col-9 p-0">
        <ChatWindow
        v-if="selectedId != 0"
        :selectedID="selectedId"
        :name="selectedName"
        />

        <div v-else class="d-flex justify-content-center align-items-center h-100">
          Select a chat to view!
        </div>
      </div>
    </div>
  </div>

</template>

