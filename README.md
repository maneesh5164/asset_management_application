# 🏢 Asset Management Application

A **Blazor Server** app for managing employees, assets, and assignments. Built with **Entity Framework Core**, **SQL Server** using a **layered architecture**.

---

## 🧰 Tech Stack
- **Frontend/Backend:** ASP.NET Blazor Server  
- **Database:** Microsoft SQL Server  
- **ORM:** Entity Framework Core  
- **Micro ORM:** Dapper  
- **Auth:** ASP.NET Identity (Single Admin Login)  
- **Architecture:** Layered (UI, Business, Data)

---

## 🏗️ Solution Structure
AssetManager/
├── AssetManager.Models # Entity classes
├── AssetManager.Data # EF Core DbContext & Repositories
├── AssetManager.Dapper # Dapper reports & queries
├── AssetManager.Business # Business logic services
└── AssetManager.UI # Blazor Server UI

---

## 🔐 Authentication
- Single Admin Login  
- Session-based authentication  
- Credentials:
 Email-admin@gmail.com
 Password- Admin@123

## SQL Scripts
- SQL scripts are at the AssetManager.Data Layer in Scripts folder in myScript.sql file

The app is not not deployed and I run it locally on my device.
