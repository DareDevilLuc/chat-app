<script setup lang="ts">
import { ref } from 'vue';


const newMessage = ref('')

const emits = defineEmits<{
  send: [text: string]
}>()

function sendMessage() {
  emits('send', newMessage.value.trim())
  newMessage.value = ''
}

</script>

<template>

<form @submit.prevent="sendMessage()" class="d-flex flex-row gap-3">
  <input type="text" v-model="newMessage" class="w-100">
  <button class="btn btn-info" type="submit">
    <i class="bi bi-send"></i>
  </button>

</form>

<div>

</div>
</template>

<style scoped>

</style>
