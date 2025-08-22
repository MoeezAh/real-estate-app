import React, { useState } from 'react';
import api from '../api/axios';
import { useNavigate } from 'react-router-dom';

export default function Register() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    try {
      await api.post('/auth/register', { email, password });
      // Automatically log in after registration
      const res = await api.post('/auth/login', { email, password });
      localStorage.setItem('token', res.data.token);
      window.dispatchEvent(new Event('storage'));
      navigate('/');
    } catch (err) {
      setError('Registration failed.');
    }
  };

  return (
    <div className="container py-5">
      <div className="row justify-content-center">
        <div className="col-12 col-md-6">
          <h2 className="fw-bold mb-4" style={{ color: '#6366f1' }}>
            <i className="bi bi-person-plus me-2"></i> Register
          </h2>
          <form onSubmit={handleSubmit} className="p-4 rounded shadow" style={{ background: 'linear-gradient(90deg, #e0e7ff 0%, #f8fafc 100%)' }}>
            <div className="mb-3">
              <label className="form-label">Email</label>
              <input type="email" className="form-control" value={email} onChange={e => setEmail(e.target.value)} required />
            </div>
            <div className="mb-3">
              <label className="form-label">Password</label>
              <input type="password" className="form-control" value={password} onChange={e => setPassword(e.target.value)} required />
            </div>
            {error && <div className="alert alert-danger">{error}</div>}
            <button type="submit" className="btn btn-primary w-100">Register</button>
          </form>
        </div>
      </div>
    </div>
  );
}
