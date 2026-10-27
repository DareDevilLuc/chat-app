<script setup lang="ts">
import { onMounted } from 'vue'

  const server = "http://localhost:5200"


onMounted(async () => {
  const res = await fetch(server + "/api/ping")
  const data = await res.json()

  console.log(data.message)
})

</script>

<template>

</template>

<style scoped>

</style>
