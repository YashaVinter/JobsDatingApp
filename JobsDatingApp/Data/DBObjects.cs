using JobsDatingApp.Data.Models;

namespace JobsDatingApp.Data
{
    public static class DBObjects
    {
        public static List<Company> Companies { get; set; }
        public static List<Vacancy> Vacancies { get; set; }
        public static List<User> Users{ get; set; }
        public static async void Initial(AppDBContext context)
        {
            if (!context.Companies.Any()){
                context.Companies.AddRange(Companies);
                context.SaveChanges();
            }
            if (!context.Vacancies.Any()){
                context.Vacancies.AddRange(Vacancies);
                context.SaveChanges();
            }
            if (!context.Users.Any())
            {
                context.Users.AddRange(Users);
                context.SaveChanges();
            }
        }
        static DBObjects()
        {
            Companies = new List<Company>()
            {
                new Company()
                {
                    Id=1,
                    Name="Сбербанк",
                    ShortDesc="ОАО Сбербанк",
                    FullDesc="State company Sber",
                    PhotoPath="/Files/CompanyPhoto/Sber.jpg",
                    Vacancies = new()
                },
                new Company()
                {
                    Id=2,
                    Name="VTB",
                    ShortDesc="ОАО ВТБ",
                    FullDesc="Private company VTB",
                    PhotoPath="/Files/CompanyPhoto/Vtb.jpg",
                    Vacancies = new()
                },
                new Company()
                {
                    Id=3,
                    Name="Тинькофф",
                    ShortDesc="ОАО Тинькофф",
                    FullDesc="Private company Sber",
                    PhotoPath="/Files/CompanyPhoto/Tinkoff.png",
                    Vacancies = new()
                },
                new Company()
                {
                    Id=4,
                    Name="Яндекс",
                    ShortDesc="ОАО Яндекс",
                    FullDesc="Private company Yandex",
                    PhotoPath="/Files/CompanyPhoto/Yandex.png",
                    Vacancies = new()
                }
            };
            Vacancies = new List<Vacancy>()
            {
                new Vacancy()
                {
                    Id = 1,
                    Name = "Junior Java разработчик",
                    CompanyId = 1,
                    Salary = 50000,
                    ShortDesc ="Junior Java разработчик в Сбербанк",
                    FullDesc ="Сбер сейчас это, крупнейшая цифровая экосистема. Технобренд, объединяющий лучшие мировые практики и современный стек. Сбер работает над созданием экосистемы удобных онлайн сервисов в самых разных сферах. Сейчас в нее входит более 50 компаний. Среди них- онлайн-кинотеатр Okko, сервис доставки еды Delivery Club и многие другие.Мы в поиске Java разработчика_,_ в команду под новый проект- Реализация приложения для внутреннего пользования сотрудников банка.",
                    Company = new()
                },
                new Vacancy()
                {
                    Id = 2,
                    Name = "SQL-разработчик",
                    CompanyId = 1,
                    Salary = 100000,
                    ShortDesc ="SQL-разработчик в Сбербанк",
                    FullDesc =@"Ключевая цель нашего проекта - создание\сопровождение хранилища данных по операционным расходам. Мы разрабатываем инструменты управления операционными расходами (Dashboards, аналитика, OLAP-Кубы) для внутренних клиентов Группы Сбербанк, с помощью которых наши пользователи смогут повысить эффективность управления операционными расходами. Основной стек: MS SQL, PostgreSQL",
                    Company = new()
                },
                new Vacancy()
                {
                    Id = 3,
                    Name = "Разработчик Full-Stack .NET",
                    CompanyId = 3,
                    Salary = 45000,
                    ShortDesc ="Разработчик Full-Stack .NET в Тинькофф",
                    FullDesc ="Мы разрабатываем облачную платформу виртуальных рабочих мест TWork.Платформа дает возможность сотрудникам компании работать удаленно, без привязки к офисному рабочему месту.Внутри платформы мы их обучаем и мотивируем, организуем рабочие процессы и общение, контроль качества и геймификацию.Сегодня на платформе работает 10 000 удаленных сотрудников в режиме 24/7 и в пике создают нагрузку 1500 RPS + 5000 realtime соединений, обрабатывая больше 1.5 миллиона заявок в сутки.Ищем нового игрока в нашу команду, готового учиться, развиваться с желанием создавать надежные, оптимальные и смелые технические решения. Мы предлагаем возможность удалённой работы и гибкого планирования своего времени.",
                    Company = new()
                },
                new Vacancy()
                {
                    Id = 4,
                    Name = "Ведущий инженер DevOps Cloud",
                    CompanyId = 2,
                    Salary = 110000,
                    ShortDesc ="Ведущий инженер DevOps Cloud в ВТБ",
                    FullDesc ="Обязанности:администрирование сервисов облачной платформы;настраивание и поддержка CI/ CD;автоматизация и документирование DevOps процессов;участие в разработке архитектурных решений;участие в создании стендов;исследование / тестирование возможности использования технологий / решений / оборудования в существующей и разрабатываемой инфраструктуре облачной платформы; ",
                    Company = new()
                },
                new Vacancy()
                {
                    Id = 5,
                    Name = "Разработчик бэкенда",
                    CompanyId = 4,
                    Salary = 110000,
                    ShortDesc ="Разработчик бэкенда в Яндекс.Практикум",
                    FullDesc = "Требуемый опыт работы: 1–3 года Полная занятость, гибкий график Яндекс.Практикум — сервис онлайн-образования, который выходит на рынок США и Европы. Мы помогаем людям расти — на работе и в жизни. Наша цель — построить на платформе Практикума универсальный конструктор образовательного опыта. В нашей команде десятки специалистов из разных областей, и мы постоянно растем. Занимаемся внутренними сервисами Практикума: создаем удобные инструменты и сами ими пользуемся, разрабатываем курсы, организуем спринты. Мы получаем обратную связь напрямую от пользователей-коллег и точно знаем, что и зачем делаем. Если вы считаете, что каждый может научиться новому, — присоединяйтесь к нашей команде.",
                    Company = new()
                }
            };
            BindCompaniesAndVacanies();
            Users = new List<User> 
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob",
                    Email = "test@mail.com",
                    Password = "123456",
                    Login = "Bob123"
                }
            };
            NullingEntities();
        }
        private static void NullingEntities() 
        {
            foreach (var c in Companies)
            {
                c.Vacancies = null;
            }
            foreach (var v in Vacancies)
            {
                v.Company = null;
            }
            foreach (var u in Users)
            {
                u.LastViewedVacancy = null;
                u.LikedVacancies = null;
            }
        }
        private static void BindCompaniesAndVacanies()
        {
            foreach (var bindingVacancy in Vacancies)
            {
                var bindingCompany = Companies.First(c => c.Id == bindingVacancy.CompanyId);
                bindingVacancy.Company = bindingCompany;
                bindingCompany.Vacancies.Add(bindingVacancy);
            }
        }
    }
}
