

# Vacancy Parser System

## Опис

Це мікросервісна система для парсингу вакансій, перевірки телефонних номерів та збереження результатів у базу даних і CSV файл.

### Архітектура

Система складається з кількох сервісів:

- VacancyParser — парсить вакансії та витягує номери телефонів
- CheckNumberPhoneAPI — перевіряє номери та зберігає їх у базу даних
- PostgreSQL — база даних
- FileService (опціонально) — віддає CSV файл через HTTP

### Функціонал

- Парсинг вакансій з сайту
- Витягування номерів телефонів
- Перевірка номерів через API
- Збереження в PostgreSQL
- Запис у CSV файл
- Фільтрація контенту через конфіг

### Технології

- .NET 8
- ASP.NET Core
- PostgreSQL
- Docker / Docker Compose
- Playwright (Chromium)

### Запуск

```bash
git clone <repo_url>
cd VacansyProject
docker-compose up --build
````

### Доступ

* API: [http://localhost:5000](http://localhost:5000)
* FileService: [http://localhost:6000/file](http://localhost:6000/file)

### Структура

```
VacansyProject/
├── CheckNumberPhoneAPI/
├── VacancyParser/
├── FileService/
├── data/
├── config/
├── docker-compose.yml
```

### Дані

CSV файл:

```
data/Output/leads.csv
```

База даних:

```
Host: localhost
Port: 5432
Database: phones
User: postgres
Password: postgres
```

### Конфіг

```
config/config.json
```

Містить список заборонених слів.

### Примітки

* Дані зберігаються через Docker volumes
* Папки bin, obj, data не додаються в git
* Playwright встановлює Chromium під час build

---

## Description

This is a microservice-based system for parsing job vacancies, validating phone numbers, and storing results in a database and CSV file.

### Architecture

The system consists of:

* VacancyParser — parses vacancies and extracts phone numbers
* CheckNumberPhoneAPI — validates numbers and stores them in the database
* PostgreSQL — database
* FileService (optional) — serves CSV file via HTTP

### Features

* Vacancy parsing
* Phone number extraction
* Validation via API
* Storage in PostgreSQL
* CSV export
* Content filtering via config

### Technologies

* .NET 8
* ASP.NET Core
* PostgreSQL
* Docker / Docker Compose
* Playwright (Chromium)

### Run

```bash
git clone <repo_url>
cd VacansyProject
docker-compose up --build
```

### Access

* API: [http://localhost:5000](http://localhost:5000)
* FileService: [http://localhost:6000/file](http://localhost:6000/file)

### Structure

```
VacansyProject/
├── CheckNumberPhoneAPI/
├── VacancyParser/
├── FileService/
├── data/
├── config/
├── docker-compose.yml
```

### Data

CSV file:

```
data/Output/leads.csv
```

Database:

```
Host: localhost
Port: 5432
Database: phones
User: postgres
Password: postgres
```

### Config

```
config/config.json
```

Contains blacklist words.

### Notes

* Data is stored using Docker volumes
* bin, obj, data folders are excluded from git
* Playwright installs Chromium during build


