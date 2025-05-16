
# 🧠 Fullstack Task Series – .NET 8 & Angular 17

This repository contains 3 separate fullstack tasks developed using .NET 8 Web API and Angular 17 (standalone). Each task demonstrates realistic data communication between frontend and backend using modern architecture and tools.

## 📁 Project Structure

```
Tasks/
│
├── SecureBankingApp/
│   ├── backend/       → Login logic (password hash verification)
│   └── frontend/      → Login form (sends SHA-256 hashed password)
│
├── TransactionApp/
│   ├── backend/       → Basic transaction saving (Date, Description, Amount)
│   └── frontend/      → Transaction form + form validation
│
└── RealTimeTransactionApp/
    ├── backend/       → Web API with SignalR for real-time broadcasting
    └── frontend/      → Angular app that listens to and displays live updates
```

## ✅ Task 1 – SecureBankingApp

**Goal:** Handle user login by hashing the password on the frontend (SHA-256) and verifying it on the backend.

- `POST /api/auth/login`
- If the hash matches the stored one, login is successful.

## ✅ Task 2 – TransactionApp

**Goal:** User enters a date, description, and amount; the data is sent to the backend and logged.

- `POST /api/transactions/save`
- Backend logs the incoming data.
- Reactive Forms are used in the Angular frontend.

## ✅ Task 3 – RealTimeTransactionApp

**Goal:** Broadcast new transactions to all connected users using SignalR in real-time.

- SignalR Hub: `/hubs/transaction`
- API Endpoint: `POST /api/transaction/save`
- Each submitted transaction is broadcasted to all clients.

## 💻 Technologies Used

- .NET 8 Web API (Minimal / Controller based)
- Angular 17 (Standalone + Vite + Reactive Forms)
- SignalR (Real-time communication)
- SHA-256 (Password hashing)
- CORS / HTTPClient / FormGroup

## 🚀 How to Run

### Backend

```bash
cd [ProjectName]/backend
dotnet run
```

### Frontend

```bash
cd [ProjectName]/frontend
npm install
ng serve
```

> `[ProjectName]` → SecureBankingApp, TransactionApp, or RealTimeTransactionApp

## 📌 Notes

- Each project demonstrates a realistic and modern use of Angular and .NET 8.
- Topics like password security, CORS, SignalR, and reactive forms are covered.
