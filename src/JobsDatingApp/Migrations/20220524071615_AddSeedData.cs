using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsDatingApp.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6a9f3e8-d8c6-42a2-b934-614d1f8e8b8d"));

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDesc",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullDesc",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDesc",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullDesc",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "FullDesc", "Name", "PhotoPath", "Rating", "ShortDesc" },
                values: new object[,]
                {
                    { 239811, null, "Team Force", "https://hhcdn.ru/employer-logo-original/965073.png", null, null },
                    { 578702, null, "ArtVolkov.ru", "https://hhcdn.ru/employer-logo-original/871828.jpg", null, null },
                    { 723714, null, "ZennoLab", "https://hhcdn.ru/employer-logo-original/577373.png", null, null },
                    { 776314, null, "Парфюмерно-косметический супермаркет Золотое Яблоко", "https://hhcdn.ru/employer-logo-original/894970.jpg", null, null },
                    { 966589, null, "ТУЛА Консалтинг", "https://hhcdn.ru/employer-logo-original/243680.jpg", null, null },
                    { 3836446, null, "PointPay", "https://hhcdn.ru/employer-logo-original/856418.png", null, null },
                    { 4300631, null, "Kvando Technologies", "https://hhcdn.ru/employer-logo-original/683838.png", null, null },
                    { 4400182, null, "HIVE", "https://hhcdn.ru/employer-logo-original/698667.png", null, null },
                    { 4712659, null, "Progressive Mind", "https://hhcdn.ru/employer-logo-original/758968.png", null, null },
                    { 4759060, null, "HR Prime", "https://hhcdn.ru/employer-logo-original/792449.jpg", null, null },
                    { 5076342, null, "Gara.capital", "", null, null },
                    { 5122356, null, "ГравиЛинк", "https://hhcdn.ru/employer-logo-original/835607.png", null, null },
                    { 5402004, null, "Lenkep recruitment", "https://hhcdn.ru/employer-logo-original/933153.png", null, null },
                    { 5451960, null, "ВФМ Технолоджи", "https://hhcdn.ru/employer-logo-original/878699.png", null, null },
                    { 6089401, null, "RuWork", "https://hhcdn.ru/employer-logo-original/949243.png", null, null },
                    { 6166013, null, "Федорова Татьяна", "", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Name", "Password" },
                values: new object[] { new Guid("78351b29-7db6-4bcd-b785-54c54d1d9b7c"), "test@mail.com", "Bob123", "Bob", "123456" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Address", "CompanyId", "FullDesc", "Name", "PhotoPath", "Salary", "ShortDesc" },
                values: new object[,]
                {
                    { 48457284, "Москва", 578702, "Опыт <highlighttext>разработки</highlighttext> современных, безопасных, масштабируемых сложных приложений. Практический опыт работы с крипто‐токеномикой, консенсусными протоколами блокчейна, P2P‐сетями...", "Разработчик Solidity/Разработчик Rust/Разработчик Go/Разработчтик python(удаленно)", null, 600000.0, "Опыт <highlighttext>разработки</highlighttext> современных, безопасных, масштабируемых сложных приложений. Практический опыт работы с крипто‐токеномикой, консенсусными протоколами блокчейна, P2P‐сетями..." },
                    { 49361125, "Москва", 723714, "Опыт <highlighttext>разработки</highlighttext> на C не менее 3 лет. Способности работы в больших проектах, таких как Chromium. Умение разбираться в чужом...", "Chromium C++ Developer (удаленно)", null, 350000.0, "Опыт <highlighttext>разработки</highlighttext> на C не менее 3 лет. Способности работы в больших проектах, таких как Chromium. Умение разбираться в чужом..." },
                    { 51540865, "Санкт-Петербург", 5122356, "применять все знания и опыт в сфере IT для <highlighttext>разработки</highlighttext> уникальных продуктов, которыми можно гордиться. - имели твёрдые фундаментальные знания математики...", "Программист-разработчик игр (Senior)", null, 360000.0, "применять все знания и опыт в сфере IT для <highlighttext>разработки</highlighttext> уникальных продуктов, которыми можно гордиться. - имели твёрдые фундаментальные знания математики..." },
                    { 54397526, "Нижний Новгород", 723714, "Опыт <highlighttext>разработки</highlighttext> на C не менее 3 лет. Способности работы в больших проектах, таких как Chromium. Умение разбираться в чужом...", "Chromium C++ Developer (удаленно)", null, 350000.0, "Опыт <highlighttext>разработки</highlighttext> на C не менее 3 лет. Способности работы в больших проектах, таких как Chromium. Умение разбираться в чужом..." },
                    { 55162113, "Москва", 5402004, "2 years experience in Solidity. - Availability of embedded smart contracts. - Strong experience in Truffle/ Waffle/ Hardhat/ Brownie. - Brilliant engineering, math...", "Solidity Developer", null, 540000.0, "2 years experience in Solidity. - Availability of embedded smart contracts. - Strong experience in Truffle/ Waffle/ Hardhat/ Brownie. - Brilliant engineering, math..." },
                    { 55162514, "Москва", 6166013, "КОММЕРЧЕСКИЙ опыт в геймдеве в качестве Unity от 6-х лет - обязателен! Наличие портфолио с опубликованными играми, среди которых есть...", "Unity Developer (Senior)", null, 500000.0, "КОММЕРЧЕСКИЙ опыт в геймдеве в качестве Unity от 6-х лет - обязателен! Наличие портфолио с опубликованными играми, среди которых есть..." },
                    { 55225298, "Москва", 4712659, "Понимание современных технологий и инструментов, применяемых в <highlighttext>разработке</highlighttext>. Опыт инструментирования кода для мониторинга ключевых показателей корректности работы приложения. ", "Python Developer (в ОАЭ)", null, 330000.0, "Понимание современных технологий и инструментов, применяемых в <highlighttext>разработке</highlighttext>. Опыт инструментирования кода для мониторинга ключевых показателей корректности работы приложения. " },
                    { 55248083, "Москва", 3836446, "Знакомство с Amazon Web Services. Опыт <highlighttext>разработки</highlighttext> криптовалютных кошельков / криптовалютных бирж / криптовалютных торговых роботов / криптовалютных платежных систем или опыт работы...", "Senior PHP Developer", null, 475000.0, "Знакомство с Amazon Web Services. Опыт <highlighttext>разработки</highlighttext> криптовалютных кошельков / криптовалютных бирж / криптовалютных торговых роботов / криптовалютных платежных систем или опыт работы..." },
                    { 55264163, "Хабаровск", 776314, "Опыт <highlighttext>разработки</highlighttext> .NetCore приложений. Знание TPL, async/await. TSQL на уровне написания процедур и функций. Знание Mongodb, Redis. ", ".NetCore developer", null, 250000.0, "Опыт <highlighttext>разработки</highlighttext> .NetCore приложений. Знание TPL, async/await. TSQL на уровне написания процедур и функций. Знание Mongodb, Redis. " },
                    { 55338997, "Москва", 4400182, "Для успешного прохождения собеседований важно хорошо знать чистый JS, остальному готовы обучать.", "Senior Fullstack Developer", null, 345000.0, "Для успешного прохождения собеседований важно хорошо знать чистый JS, остальному готовы обучать." },
                    { 55341190, "Брянск", 4300631, "Какие знания необходимы: Желание перейти на Golang, имея опыт в backend <highlighttext>разработке</highlighttext>.", "Backend разработчик", null, 170000.0, "Какие знания необходимы: Желание перейти на Golang, имея опыт в backend <highlighttext>разработке</highlighttext>." },
                    { 55403948, "Москва", 5451960, "Деплой: Gitlab CI/CD. Необходимые навыки: - Опыт серверной <highlighttext>разработки</highlighttext> более 2х лет. - Опыт <highlighttext>разработки</highlighttext> на Golang от 3х...", "Golang developer \\ Разработчик Golang", null, 300000.0, "Деплой: Gitlab CI/CD. Необходимые навыки: - Опыт серверной <highlighttext>разработки</highlighttext> более 2х лет. - Опыт <highlighttext>разработки</highlighttext> на Golang от 3х..." },
                    { 55502178, "Санкт-Петербург", 6089401, "...заказчиками от 1 года. Готовность предоставить рекомендацию от зарубежных заказчиков / коллег. Опыт работы в области программной <highlighttext>разработки</highlighttext> от 3 лет.", "Senior Software Developer (upwork / иностранный заказчик)", null, 570000.0, "...заказчиками от 1 года. Готовность предоставить рекомендацию от зарубежных заказчиков / коллег. Опыт работы в области программной <highlighttext>разработки</highlighttext> от 3 лет." },
                    { 55526119, "Москва", 4759060, "Мы принимаем разные профили на должность <highlighttext>разработчика</highlighttext> C, независимо от прежней специализации и многолетнего опыта. Для нас важнее оценить способности...", "С++ Developer", null, 650000.0, "Мы принимаем разные профили на должность <highlighttext>разработчика</highlighttext> C, независимо от прежней специализации и многолетнего опыта. Для нас важнее оценить способности..." },
                    { 55527354, "Тула", 966589, "C#/.NET 4.8, .NET Core, ASP.NET MVC, Windows Services, T-SQL (backend) JavaScript, CSS, HTML, Less (client), REST API. ", ".NET developer (middle)", null, 165000.0, "C#/.NET 4.8, .NET Core, ASP.NET MVC, Windows Services, T-SQL (backend) JavaScript, CSS, HTML, Less (client), REST API. " },
                    { 55857212, "Москва", 3836446, "Будет плюсом:  Профильное высшее образование (математическое или техническое).  Имеете опыт <highlighttext>разработки</highlighttext> подобных решений (Ставки на спорт/Gambling/Poker/Trade/Exchange).  ", "Senior Go разработчик", null, 450000.0, "Будет плюсом:  Профильное высшее образование (математическое или техническое).  Имеете опыт <highlighttext>разработки</highlighttext> подобных решений (Ставки на спорт/Gambling/Poker/Trade/Exchange).  " },
                    { 55867445, "Москва", 239811, "Знание C#. Postgresql. Опыт с Camunda (нужно работать с Camunda RestApi и с Camunda External Task). Возможности профессионального развития: можно...", "Backend developer C# (Senior / Middle+), удаленно", null, 400000.0, "Знание C#. Postgresql. Опыт с Camunda (нужно работать с Camunda RestApi и с Camunda External Task). Возможности профессионального развития: можно..." },
                    { 55871430, "Москва", 5076342, "Знать stl C, устройства работы стандартных контейнеров, времени работы методов. -- Иметь опыт промышленной <highlighttext>разработки</highlighttext> от 1 года. -- Владеть bash, понимать...", "Quantitative Developer", null, 400000.0, "Знать stl C, устройства работы стандартных контейнеров, времени работы методов. -- Иметь опыт промышленной <highlighttext>разработки</highlighttext> от 1 года. -- Владеть bash, понимать..." },
                    { 55871446, "Санкт-Петербург", 5076342, "Знать stl C, устройства работы стандартных контейнеров, времени работы методов. -- Иметь опыт промышленной <highlighttext>разработки</highlighttext> от 1 года. -- Владеть bash, понимать...", "Quantitative Developer", null, 400000.0, "Знать stl C, устройства работы стандартных контейнеров, времени работы методов. -- Иметь опыт промышленной <highlighttext>разработки</highlighttext> от 1 года. -- Владеть bash, понимать..." },
                    { 55871487, "Москва", 5076342, "Опыт <highlighttext>разработки</highlighttext> С от 4 лет. - Опыт многопоточной/асинхронной <highlighttext>разработки</highlighttext> от 4 лет. - Опыт <highlighttext>разработки</highlighttext> High-Load/Low-Latency сервисов. - ", "Senior Software Engineer", null, 650000.0, "Опыт <highlighttext>разработки</highlighttext> С от 4 лет. - Опыт многопоточной/асинхронной <highlighttext>разработки</highlighttext> от 4 лет. - Опыт <highlighttext>разработки</highlighttext> High-Load/Low-Latency сервисов. - " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("78351b29-7db6-4bcd-b785-54c54d1d9b7c"));

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 48457284);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 49361125);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 51540865);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 54397526);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55162113);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55162514);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55225298);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55248083);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55264163);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55338997);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55341190);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55403948);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55502178);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55526119);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55527354);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55857212);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55867445);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55871430);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55871446);

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 55871487);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 239811);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 578702);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 723714);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 776314);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 966589);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3836446);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4300631);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4400182);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4712659);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4759060);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5076342);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5122356);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5402004);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5451960);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6089401);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6166013);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDesc",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullDesc",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDesc",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullDesc",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "FullDesc", "Name", "PhotoPath", "Rating", "ShortDesc" },
                values: new object[,]
                {
                    { 1, "State company Sber", "Сбербанк", "/Files/CompanyPhoto/Sber.jpg", null, "ОАО Сбербанк" },
                    { 2, "Private company VTB", "VTB", "/Files/CompanyPhoto/Vtb.jpg", null, "ОАО ВТБ" },
                    { 3, "Private company Sber", "Тинькофф", "/Files/CompanyPhoto/Tinkoff.jpg", null, "ОАО Тинькофф" },
                    { 4, "Private company Yandex", "Яндекс", "/Files/CompanyPhoto/Yandex.jpg", null, "ОАО Яндекс" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Name", "Password" },
                values: new object[] { new Guid("e6a9f3e8-d8c6-42a2-b934-614d1f8e8b8d"), "test@mail.com", "Bob123", "Bob", "123456" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Address", "CompanyId", "FullDesc", "Name", "PhotoPath", "Salary", "ShortDesc" },
                values: new object[,]
                {
                    { 1, null, 1, "Сбер сейчас это, крупнейшая цифровая экосистема. Технобренд, объединяющий лучшие мировые практики и современный стек. Сбер работает над созданием экосистемы удобных онлайн сервисов в самых разных сферах. Сейчас в нее входит более 50 компаний. Среди них- онлайн-кинотеатр Okko, сервис доставки еды Delivery Club и многие другие.Мы в поиске Java разработчика_,_ в команду под новый проект- Реализация приложения для внутреннего пользования сотрудников банка.", "Junior Java разработчик", null, 50000.0, "Junior Java разработчик в Сбербанк" },
                    { 2, null, 1, "Ключевая цель нашего проекта - создание\\сопровождение хранилища данных по операционным расходам. Мы разрабатываем инструменты управления операционными расходами (Dashboards, аналитика, OLAP-Кубы) для внутренних клиентов Группы Сбербанк, с помощью которых наши пользователи смогут повысить эффективность управления операционными расходами. Основной стек: MS SQL, PostgreSQL", "SQL-разработчик", null, 100000.0, "SQL-разработчик в Сбербанк" },
                    { 3, null, 3, "Мы разрабатываем облачную платформу виртуальных рабочих мест TWork.Платформа дает возможность сотрудникам компании работать удаленно, без привязки к офисному рабочему месту.Внутри платформы мы их обучаем и мотивируем, организуем рабочие процессы и общение, контроль качества и геймификацию.Сегодня на платформе работает 10 000 удаленных сотрудников в режиме 24/7 и в пике создают нагрузку 1500 RPS + 5000 realtime соединений, обрабатывая больше 1.5 миллиона заявок в сутки.Ищем нового игрока в нашу команду, готового учиться, развиваться с желанием создавать надежные, оптимальные и смелые технические решения. Мы предлагаем возможность удалённой работы и гибкого планирования своего времени.", "Разработчик Full-Stack .NET", null, 45000.0, "Разработчик Full-Stack .NET в Тинькофф" },
                    { 4, null, 2, "Обязанности:администрирование сервисов облачной платформы;настраивание и поддержка CI/ CD;автоматизация и документирование DevOps процессов;участие в разработке архитектурных решений;участие в создании стендов;исследование / тестирование возможности использования технологий / решений / оборудования в существующей и разрабатываемой инфраструктуре облачной платформы; ", "Ведущий инженер DevOps Cloud", null, 110000.0, "Ведущий инженер DevOps Cloud в ВТБ" },
                    { 5, null, 4, "Требуемый опыт работы: 1–3 года Полная занятость, гибкий график Яндекс.Практикум — сервис онлайн-образования, который выходит на рынок США и Европы. Мы помогаем людям расти — на работе и в жизни. Наша цель — построить на платформе Практикума универсальный конструктор образовательного опыта. В нашей команде десятки специалистов из разных областей, и мы постоянно растем. Занимаемся внутренними сервисами Практикума: создаем удобные инструменты и сами ими пользуемся, разрабатываем курсы, организуем спринты. Мы получаем обратную связь напрямую от пользователей-коллег и точно знаем, что и зачем делаем. Если вы считаете, что каждый может научиться новому, — присоединяйтесь к нашей команде.", "Разработчик бэкенда", null, 110000.0, "Разработчик бэкенда в Яндекс.Практикум" }
                });
        }
    }
}
