import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5093/api', // Synced with backend launchSettings.json
});

// Add JWT token to requests if available
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

export default api;
