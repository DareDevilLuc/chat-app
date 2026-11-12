<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router';

const router = useRouter()

const isValid = ref(false)
const email = ref('')
const password = ref('')
const showPassword = ref(false)
const error = ref('')
const success = ref('')


const emailRules = [
  v => !!v || 'E-mail is required.',
  v => /.+@.+\..+/.test(v) || 'E-mail must be valid.'
]

const passwordRules = [
  v => !!v || 'Password is required.',
  v => (v && v.length >= 6) || 'Password must be at least 6 characters.'
]

const handleLogin = async () => {
  if (isValid.value) {
    try {
      const response = await fetch('http://localhost:5200/api/auth/login',
        {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            email: email.value,
            password: password.value
          })
        })

      const data = await response.json().catch(() => null)

      if (!response.ok) {
        error.value = Array.isArray(data)
          ? data.map(e => e.description).join(', ')
          : data ?? 'Login Failed';

        return;
      }

      error.value = ''
      success.value = 'Success login'
      localStorage.setItem('token', data.token)

      router.push('/main')

    }
    catch {
      error.value = "Error logging in"
    }
  }
}
</script>

<template>
  <v-container class="vh-100 d-flex justify-content-center align-items-center">
    <v-card class="d-flex flex-column elevation-12 pa-4" width="450">
      <v-card-title class="text-h5 text-center font-weight-bold mb-2">
          Login to your Account
      </v-card-title>
      <v-card-subtitle class="text-center mb-4">
        Login to get started
      </v-card-subtitle>

      <v-card-text>
        <v-form ref="form" v-model="isValid" @submit.prevent="handleLogin">
          <v-text-field v-model="email" label="Email Address" prepend-inner-icon="mdi-email" variant="outlined"
            density="comfortable" :rules="emailRules" required class="mb-3"></v-text-field>

          <v-text-field v-model="password" label="Password" prepend-inner-icon="mdi-lock"
            :type="showPassword ? 'text' : 'password'" :append-inner-icon="showPassword ? 'mdi-eye-off' : 'mdi-eye'"
            @click:append-inner="showPassword = !showPassword" variant="outlined" density="comfortable"
            :rules="passwordRules" required class="mb-4"></v-text-field>

          <v-btn type="submit" color="primary" block size="large" :disabled="!isValid" class="mt-2">
            Sign Up
          </v-btn>
        </v-form>
      </v-card-text>

      <v-card-actions class="justify-center">
        <span class="text-body-2">Don't have an account? </span>
        <v-btn variant="text" color="primary" to="/signup">
          Sign up
        </v-btn>
      </v-card-actions>

    <div class="d-flex w-100 justify-content-center align-items-center">
      <p v-if="success" class="info"> {{ success }} </p>
      <p v-if="error"> {{ error }}</p>
    </div>
    </v-card>

  </v-container>
</template>

