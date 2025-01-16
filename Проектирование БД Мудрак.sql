-- Таблица Торговая организация
CREATE TABLE торговая_организация (
    id INT PRIMARY KEY IDENTITY(1,1), 
    название_организации NVARCHAR(255) NOT NULL,
    адрес NVARCHAR(255) NOT NULL,
    директор NVARCHAR(255) NOT NULL,
    налоговый_номер NVARCHAR(50) NOT NULL
);

-- Таблица Торговая точка
CREATE TABLE торговая_точка (
    id INT PRIMARY KEY IDENTITY(1,1), 
    название_точки NVARCHAR(255) NOT NULL,
    тип_точки NVARCHAR(100) NOT NULL, 
    организация_id INT FOREIGN KEY REFERENCES торговая_организация(id),
    адрес NVARCHAR(255) NOT NULL,
    менеджер NVARCHAR(255) NOT NULL
);

-- Таблица Продавцы
CREATE TABLE продавцы (
    id INT PRIMARY KEY IDENTITY(1,1), 
    фамилия NVARCHAR(255) NOT NULL,
    имя NVARCHAR(255) NOT NULL,
    отчество NVARCHAR(255),
    торговая_точка_id INT FOREIGN KEY REFERENCES торговая_точка(id),
    должность NVARCHAR(100),
    год_рождения INT CHECK (год_рождения > 1900 AND год_рождения <= 2023), 
    пол CHAR(1) CHECK (пол IN ('M', 'F')), 
    адрес_проживания NVARCHAR(255),
    город NVARCHAR(100)
);

-- Таблица Поставщики
CREATE TABLE поставщики (
    id INT PRIMARY KEY IDENTITY(1,1), 
    название_поставщика NVARCHAR(255) NOT NULL,
    вид_деятельности NVARCHAR(100) NOT NULL,
    страна NVARCHAR(100) NOT NULL,
    город NVARCHAR(100) NOT NULL,
    адрес NVARCHAR(255) NOT NULL
);

-- Таблица Заказы поставщикам
CREATE TABLE заказы_поставщикам (
    id INT PRIMARY KEY,
    торговая_точка_id INT REFERENCES торговая_точка(id),
    поставщик_id INT REFERENCES поставщики(id),
    дата_заказа DATE NOT NULL,
    статус_заказа VARCHAR(50) NOT NULL, 
    дата_доставки DATE,
    общая_сумма DECIMAL(10, 2) NOT NULL,
    список_товаров TEXT 
);

USE master;
GO

-- Create the server audit.
CREATE SERVER AUDIT Payroll_Security_Audit TO FILE (FILEPATH = 'C:\Audits');
GO

-- Enable the server audit.
ALTER SERVER AUDIT Payroll_Security_Audit
WITH (STATE = ON);

-- Создаем спецификацию аудита.
CREATE SERVER AUDIT SPECIFICATION Security_Audit_Spec
FOR SERVER AUDIT Payroll_Security_Audit
ADD (FAILED_LOGIN_GROUP),                           
ADD (LOGIN_CHANGE_PASSWORD_GROUP),                  
ADD (BACKUP_RESTORE_GROUP);                              
GO

-- Включаем спецификацию аудита.
ALTER SERVER AUDIT SPECIFICATION Security_Audit_Spec
WITH (STATE = ON);
GO

USE [торговая организация];
GO

-- Создаем аудит на уровне базы данных.
CREATE DATABASE AUDIT SPECIFICATION Database_Audit_Spec
FOR SERVER AUDIT Payroll_Security_Audit
ADD (INSERT ON OBJECT::dbo.торговая_организация BY [public]),
ADD (UPDATE ON OBJECT::dbo.торговая_организация BY [public]),
ADD (DELETE ON OBJECT::dbo.торговая_организация BY [public]);
GO

-- Включаем спецификацию аудита.
ALTER DATABASE AUDIT SPECIFICATION Database_Audit_Spec 
WITH (STATE = ON);
GO

-- Вставка новой записи
INSERT INTO торговая_организация (название_организации, адрес, директор, налоговый_номер)
VALUES ('Тестовая Организация', 'Улица Тестовая, 1', 'Иванов И.И.', '1234567890');

-- Обновление существующей записи
UPDATE dbo.торговая_организация
SET адрес = 'Улица Обновленная, 2'
WHERE id = 2; 

-- Удаление записи
DELETE FROM dbo.торговая_организация
WHERE id = 2; 

SELECT *
FROM sys.fn_get_audit_file('C:\Audits\*.sqlaudit', DEFAULT, DEFAULT);
