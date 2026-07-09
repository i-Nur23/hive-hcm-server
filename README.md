# HiveHCM

Прототип HCM-системы (Human Capital Management) для управления человеческим капиталом на предприятии. Система предоставляет руководителям инструменты для контроля за подразделением/предприятием: подбор персонала, управление структурой компании, обучение сотрудников и отслеживание настроения команды.

Выпускная квалификационная работа, КНИТУ-КАИ, кафедра прикладной математики и информатики, направление 09.03.04 «Программная инженерия».

## Актуальность

- Оптимизация бизнес-процессов
- Рост значимости человеческого капитала
- Необходимость в управлении данными и аналитика

## Цель и задачи

**Цель:** разработка прототипа HCM-системы, предоставляющего руководителям возможность осуществлять контроль за человеческим капиталом своего подразделения/предприятия.

**Задачи:**
1. Проанализировать предметную область, в частности, существующие системы
2. Определить основной функционал разрабатываемой системы
3. Разработать архитектуру системы
4. Изучить и выбрать инструменты для разработки программного продукта
5. Спроектировать базы данных
6. Реализовать продукт в виде веб-приложения
7. Подготовить руководство пользователя и руководство разработчика

## Функционал (Use Case диаграмма)

Система поддерживает три роли: **CEO**, **HR** и **обычный работник** — каждая со своим набором доступных действий: от регистрации компании и управления подразделениями до подбора персонала, ведения курсов обучения и оценки настроения сотрудников.

<img width="1721" height="866" alt="image" src="https://github.com/user-attachments/assets/f3d1098b-e950-42c3-bc32-1cb7e40ec040" />

## Архитектура

Проект построен на микросервисной архитектуре с разделением ответственности внутри каждого сервиса по паттерну Controller–Service–Repository, а часть сервисов дополнительно использует CQRS для разделения операций чтения и записи.

Клиент обращается к API-шлюзу (NGINX), который маршрутизирует запросы к отдельным микросервисам (пользователи, персонал, подбор персонала, обучение, медиа-сервер, настроение подчинённых). Сервисы взаимодействуют друг с другом через брокер сообщений, к которому также подключены сервис отправки писем и сервис-парсер информации о странах.

<img width="1460" height="864" alt="image" src="https://github.com/user-attachments/assets/c435bc3c-7dc6-4189-a929-741b3f1db1c1" />

## Стек технологий

### Веб-фреймворки

Сервер — ASP.NET Core и Fiber (Go), клиент — Next.js.

### Базы данных

MS SQL Server и PostgreSQL

### Вспомогательные инструменты

Entity Framework Core, MassTransit, JWT

## Проектирование базы данных

### Инфологическая модель

<img width="1374" height="848" alt="image" src="https://github.com/user-attachments/assets/0be44f34-0ea1-4ace-9f2c-55345f014fe9" style="border: 1px solid #ccc;"/>

### Концептуальные модели

**Подсистема пользователей**

<img width="330" height="418" alt="image" src="https://github.com/user-attachments/assets/ff33eb9e-027f-4a7d-a6e7-37d3b2130107" style="border: 1px solid #ccc;"/>

**Подсистема персонала**

<img width="1193" height="826" alt="image" src="https://github.com/user-attachments/assets/0bc549b2-a69d-4ceb-ad3a-4e324c5fc827" style="border: 1px solid #e1e4e8; box-shadow: 0 1px 3px rgba(0,0,0,0.12);"/>

**Подсистема обучения**

<img width="891" height="630" alt="image" src="https://github.com/user-attachments/assets/2492b118-3e5f-478f-815c-342dbdab773e" style="border: 1px solid #ccc;"/>

**Подсистема настроения подчинённых**

<img width="821" height="510" alt="image" src="https://github.com/user-attachments/assets/211ed3ce-6b14-4f19-970a-b8f389b5aecf" style="border: 1px solid #ccc;"/>

**Подсистема подбора персонала**

<img width="1067" height="832" alt="image" src="https://github.com/user-attachments/assets/ce382c4c-f3e8-46d8-8e87-ed5738d84ad2" style="border: 1px solid #ccc;"/>

## Демонстрация работы приложения

### Вход и регистрация

<img width="790" height="526" alt="image" src="https://github.com/user-attachments/assets/aa40d67d-7c47-4644-be1c-5b8312c04f8c" style="border: 1px solid black;"/>
<img width="624" height="859" alt="image" src="https://github.com/user-attachments/assets/0b73a0ac-4725-4173-9e0c-a11f0f0b4ecf" style="border: 1px solid #ccc;"/>

### Главная страница

<img width="1729" height="893" alt="image" src="https://github.com/user-attachments/assets/e3059e99-57cf-44be-83b3-d10affad809d" style="border: 1px solid #ccc;"/>

### Профиль пользователя

<img width="1643" height="777" alt="image" src="https://github.com/user-attachments/assets/5554bd44-89d5-4c42-b248-a8fcd45d15b2" style="border: 1px solid #ccc;"/>

### Смена пароля

<img width="1173" height="447" alt="image" src="https://github.com/user-attachments/assets/1f6e66a0-fe17-496f-a264-65208773bbb0" style="border: 1px solid #ccc;"/>

### Список подразделений

<img width="1788" height="715" alt="image" src="https://github.com/user-attachments/assets/2171081e-6768-4689-b1d4-5815fcc3e2ef" style="border: 1px solid #ccc;"/>

### Список курсов

<img width="1854" height="605" alt="image" src="https://github.com/user-attachments/assets/573de904-239a-4167-83d2-6ca63d1d7e32" style="border: 1px solid #ccc;"/>

### Вакансии компании

<img width="1496" height="827" alt="image" src="https://github.com/user-attachments/assets/5bc112cd-d2dd-4eca-949e-248a54a86f00" style="border: 1px solid #ccc;"/>

### Настроение подчинённых

<img width="1404" height="737" alt="image" src="https://github.com/user-attachments/assets/4b6cc0fc-fc5b-49cd-91c8-23cda5a88045" style="border: 1px solid #ccc;"/>

## Заключение

В результате выполнения выпускной квалификационной работы был создан прототип HCM-системы для обеспечения руководителей возможностью управления человеческим капиталом, а также решены все поставленные задачи:

1. Проанализирована предметная область, в частности, существующие системы
2. Определён основной функционал разрабатываемой системы
3. Разработана архитектура системы
4. Изучены и выбраны инструменты для разработки программного продукта
5. Спроектирована база данных
6. Реализован продукт в виде веб-приложения
7. Подготовлено руководство пользователя и руководство разработчика
