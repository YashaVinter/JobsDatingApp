using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobsDatingApp.Migrations
{
    public partial class AddColumnToVacancyAndCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a4e00079-9248-4785-a40d-67720856e2f0"));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "Vacancies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Companies",
                type: "float",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ShortDesc" },
                values: new object[] { "Сбербанк", "ОАО Сбербанк" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShortDesc",
                value: "ОАО ВТБ");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "FullDesc", "Name", "PhotoPath", "Rating", "ShortDesc" },
                values: new object[,]
                {
                    { 3, "Private company Sber", "Тинькофф", "/Files/CompanyPhoto/Tinkoff.jpg", null, "ОАО Тинькофф" },
                    { 4, "Private company Yandex", "Яндекс", "/Files/CompanyPhoto/Yandex.jpg", null, "ОАО Яндекс" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Name", "Password" },
                values: new object[] { new Guid("e6a9f3e8-d8c6-42a2-b934-614d1f8e8b8d"), "test@mail.com", "Bob123", "Bob", "123456" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullDesc", "Name", "ShortDesc" },
                values: new object[] { "Сбер сейчас это, крупнейшая цифровая экосистема. Технобренд, объединяющий лучшие мировые практики и современный стек. Сбер работает над созданием экосистемы удобных онлайн сервисов в самых разных сферах. Сейчас в нее входит более 50 компаний. Среди них- онлайн-кинотеатр Okko, сервис доставки еды Delivery Club и многие другие.Мы в поиске Java разработчика_,_ в команду под новый проект- Реализация приложения для внутреннего пользования сотрудников банка.", "Junior Java разработчик", "Junior Java разработчик в Сбербанк" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullDesc", "Name", "ShortDesc" },
                values: new object[] { "Ключевая цель нашего проекта - создание\\сопровождение хранилища данных по операционным расходам. Мы разрабатываем инструменты управления операционными расходами (Dashboards, аналитика, OLAP-Кубы) для внутренних клиентов Группы Сбербанк, с помощью которых наши пользователи смогут повысить эффективность управления операционными расходами. Основной стек: MS SQL, PostgreSQL", "SQL-разработчик", "SQL-разработчик в Сбербанк" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FullDesc", "Name", "ShortDesc" },
                values: new object[] { "Обязанности:администрирование сервисов облачной платформы;настраивание и поддержка CI/ CD;автоматизация и документирование DevOps процессов;участие в разработке архитектурных решений;участие в создании стендов;исследование / тестирование возможности использования технологий / решений / оборудования в существующей и разрабатываемой инфраструктуре облачной платформы; ", "Ведущий инженер DevOps Cloud", "Ведущий инженер DevOps Cloud в ВТБ" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompanyId", "FullDesc", "Name", "ShortDesc" },
                values: new object[] { 3, "Мы разрабатываем облачную платформу виртуальных рабочих мест TWork.Платформа дает возможность сотрудникам компании работать удаленно, без привязки к офисному рабочему месту.Внутри платформы мы их обучаем и мотивируем, организуем рабочие процессы и общение, контроль качества и геймификацию.Сегодня на платформе работает 10 000 удаленных сотрудников в режиме 24/7 и в пике создают нагрузку 1500 RPS + 5000 realtime соединений, обрабатывая больше 1.5 миллиона заявок в сутки.Ищем нового игрока в нашу команду, готового учиться, развиваться с желанием создавать надежные, оптимальные и смелые технические решения. Мы предлагаем возможность удалённой работы и гибкого планирования своего времени.", "Разработчик Full-Stack .NET", "Разработчик Full-Stack .NET в Тинькофф" });

            migrationBuilder.InsertData(
                table: "Vacancies",
                columns: new[] { "Id", "Address", "CompanyId", "FullDesc", "Name", "PhotoPath", "Salary", "ShortDesc" },
                values: new object[] { 5, null, 4, "Требуемый опыт работы: 1–3 года Полная занятость, гибкий график Яндекс.Практикум — сервис онлайн-образования, который выходит на рынок США и Европы. Мы помогаем людям расти — на работе и в жизни. Наша цель — построить на платформе Практикума универсальный конструктор образовательного опыта. В нашей команде десятки специалистов из разных областей, и мы постоянно растем. Занимаемся внутренними сервисами Практикума: создаем удобные инструменты и сами ими пользуемся, разрабатываем курсы, организуем спринты. Мы получаем обратную связь напрямую от пользователей-коллег и точно знаем, что и зачем делаем. Если вы считаете, что каждый может научиться новому, — присоединяйтесь к нашей команде.", "Разработчик бэкенда", null, 110000.0, "Разработчик бэкенда в Яндекс.Практикум" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e6a9f3e8-d8c6-42a2-b934-614d1f8e8b8d"));

            migrationBuilder.DeleteData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "ShortDesc" },
                values: new object[] { "Sber", "Sber company" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShortDesc",
                value: "VTB company");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Login", "Name", "Password" },
                values: new object[] { new Guid("a4e00079-9248-4785-a40d-67720856e2f0"), "test@mail.com", "Bob123", "Bob", "123456" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FullDesc", "Name", "ShortDesc" },
                values: new object[] { "Junior position in Sber", "Junior", "Junior position" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FullDesc", "Name", "ShortDesc" },
                values: new object[] { "Middle position in Sber", "Middle", "Middle position" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CompanyId", "FullDesc", "Name", "ShortDesc" },
                values: new object[] { 2, "Junior position in Vtb", "Junior", "Junior position" });

            migrationBuilder.UpdateData(
                table: "Vacancies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FullDesc", "Name", "ShortDesc" },
                values: new object[] { "Middle position in Vtb", "Middle", "Middle position" });
        }
    }
}
