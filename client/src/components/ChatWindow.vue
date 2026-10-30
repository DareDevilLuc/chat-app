<script setup lang="ts">
import MessageList from './MessageList.vue';


defineProps<{
  selectedID: number
  name: string
}>()

</script>

<template>
  <div class="h-100 d-flex flex-column">
    <!-- header -->
    <div class="d-flex p-4 border-bottom bg-secondary lh-1 align-items-center" >
      <v-avatar image="https://github.com/mdo.png" size="50" class="me-2"/>
      <span class="text-white fs-3"> {{ name }} </span>
    </div>

    <div class="flex-grow-1 overflow-auto p-3">
      <MessageList/>
    </div>

    <div class="p-4 border-top bg-secondary">

    </div>
  </div>
</template>

<style scoped>

</style>

