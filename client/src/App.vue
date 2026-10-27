<script setup lang="ts">
import { onMounted, ref} from 'vue'

const server = "http://localhost:5200"

const message = ref('')

onMounted(async () => {
  const res = await fetch(server + "/api/ping")
  const data = await res.json()

  message.value = data.message

  console.log(data.message)
})

</script>

<template>

  The message is : {{message}}

  <button type="button" class="btn btn-primary">Primary</button>

</template>

<style scoped>

</style>
