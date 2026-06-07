# 📝 Online Quiz Application (ASP.NET)

An Online Quiz Application built using **ASP.NET Web Forms, C#, and SQL Server** as part of the DotNet Technology subject. This system allows admins to create exams and questions, and users to take quizzes, view results, and track their performance.

---

## 🚀 Features

### 👨‍🎓 User Side
- User registration and login
- View available exams
- Take timed quizzes
- Automatic score calculation
- View exam results in profile

### 👨‍💼 Admin Side
- Admin login
- Create and manage exams
- Add questions to exams
- Control exam duration and marks

---

## 🛠️ Technologies Used

- ASP.NET Web Forms
- C# (.NET Framework 4.7.2)
- SQL Server
- HTML, CSS, Bootstrap
- ADO.NET

---

## 🗄️ Database Tables

- users
- admins
- exams
- questions
- results

---

## 📸 Screenshots

### 🏠 User Home Page
<img width="1918" height="1013" alt="Screenshot 2026-06-07 213256" src="https://github.com/user-attachments/assets/cd01f409-5e69-460f-95c9-bbecf00a76a3" />


### 🧑‍💼 Admin Dashboard
<img width="1918" height="1020" alt="Screenshot 2026-06-07 213325" src="https://github.com/user-attachments/assets/17710479-6b34-4708-94e6-f0710cf14210" />

---

## ⚙️ Setup Instructions

1. Clone the repository
```bash
git clone https://github.com/Sarun-shakya/online-quiz-app.git
git clone https://github.com/Sarun-shakya/online-quiz-app.git

2. Open the project in **Visual Studio**

3. Open SQL Server and create database:

4. Run the provided SQL script to create tables

5. Update connection string in `web.config`:
<connectionStrings>
  <add name="QuizDB"
       connectionString="Data Source=YOUR_DB_SOURCE;Initial Catalog=DB_NAME;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>

6. Build and run the project (Press `F5`)
```

---

## 📂 Project Structure

```
Online_Quiz_Application
│
├── Admin/
├── App_Code/
├── Site.Master
├── web.config
└── Default.aspx
```

---

## 👨‍💻 Author

Developed by **Sarun Shakya**  
For DotNet Technology Subject Project

---

## ⭐ License

This project is for educational purposes only.
