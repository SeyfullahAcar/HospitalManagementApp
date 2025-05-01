# Hospital Management System

This is a desktop-based Hospital Management System built with C#. It allows patients to book appointments, and doctors to view and manage those appointments.
The system includes essential features such as patient management, doctor management, and appointment scheduling.

## Features

- Patient registration and management  
- Doctor information and schedules  
- Appointment booking system  
- Basic user-friendly interface  
- Built with Windows Forms and C#

## Requirements

- **Windows OS**
- **.NET Framework 4.x or later**
- **Microsoft SQL Server (LocalDB, Express, or Full Edition)**

## ⚠️ Important Note

This application requires **Microsoft SQL Server** to be installed on your computer. Without a valid SQL Server instance and connection, the application may freeze or close unexpectedly.

You must configure the correct **connection string** in the `App.config` file before running the application.

> Example:

```xml
<connectionStrings>
  <add name="HospitalDB" 
       connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=HospitalDB;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
