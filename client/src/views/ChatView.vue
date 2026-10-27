<script setup lang="ts">
import ChatList from '@/components/ChatList.vue';
import ChatWindow from '@/components/ChatWindow.vue';

</script>

<template>

  <div class="container-fluid">
    <div class="row min-vh-100">
      <div class="col-3 bg-dark text-white">
        <ChatList/>
      </div>

      <div class="col-9">
        <ChatWindow/>
      </div>
    </div>
  </div>

</template>

