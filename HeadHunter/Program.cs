using HeadHunter.Models;
using System;
using HeadHunter.Enums;
using HeadHunter.Services;
using HeadHunter.Utilits;
using System.Collections.Generic;

namespace HeadHunter
{
    internal class Program
    {
        private static string nameUser;
        static void Main(string[] args)
        {
            Menu(mainMenu);
        }
        

        /// <summary>
        /// Регистрация Работадателя 
        /// </summary>
        public static void RegistrationEmployer()
        {
            EmployerService _userService = new EmployerService();

            string firstName , surName, login, password, password2, email, companyName, description, address, sex;
            int foundationYear = 0;

            Console.Clear();
            Console.WriteLine("Введите логин:");
            login = Console.ReadLine();
            Console.WriteLine("Введите пароль, пороль должен быть не меньше 6 символов:");
            password = Console.ReadLine();
            Console.WriteLine("Повторите  пароль");
            password2 = Console.ReadLine();
            Console.WriteLine("Введите Имя:");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите Фамилию:");
            surName = Console.ReadLine();
            Console.WriteLine("Введите Пол м или ж:");
            sex = Console.ReadLine().ToLower();
            Console.WriteLine("Введите email:");
            email = Console.ReadLine();
            Console.WriteLine("Введите название компании:");
            companyName = Console.ReadLine();
            Console.WriteLine("Введите описания компании:");
            description = Console.ReadLine();
            Console.WriteLine("Введите адрес компании:");
            address = Console.ReadLine();
            Console.WriteLine("Введите год основания компании:");
            int.TryParse(Console.ReadLine(), out foundationYear );

            if (foundationYear == 0) foundationYear = DateTime.Now.Year;

            Employer employer = new Employer()
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                SurName = surName,
                Email = email,
                CompanyName = companyName,
                Description = description,
                Address = address,
                FoundationYear = foundationYear,
                Sex = sex == "м" ? Sex.Male : sex == "ж" ? Sex.Female : Sex.NoN,
            };


            Result<bool> result = _userService.RegistredUser(employer, password2);


            if (result.IsSuccess == false)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                
                RegistrationEmployer();
            }
            else
            {
                nameUser = login;
                Menu(EmployerMenu);
            }
        }

        /// <summary>
        /// Регистрация Соискателя
        /// </summary>
        public static void RegistrationEmployee()
        {
            EmployeeServes _userService = new EmployeeServes();

            string firstName, surName, login, password, password2,email, sex, empLoyeeInfo ;
            int experience =1, education = 3;

            Console.Clear();
            Console.WriteLine("Введите логин:");
            login = Console.ReadLine();
            Console.WriteLine("Введите пароль, пороль должен быть не меньше 6 символов:");
            password = Console.ReadLine();
            Console.WriteLine("Повторите  пароль");
            password2 = Console.ReadLine();
            Console.WriteLine("Введите Имя:");
            firstName = Console.ReadLine();
            Console.WriteLine("Введите Фамилию:");
            surName = Console.ReadLine();
            Console.WriteLine("Введите email:");
            email = Console.ReadLine();
            Console.WriteLine("Введите Пол м или ж:");
            sex = Console.ReadLine().ToLower();
            Console.WriteLine("Опишите свои качества:");
            empLoyeeInfo = Console.ReadLine();

            Console.WriteLine("Введите \n" +
                              "1: Нет опыта \n" +
                              "2: От 1 года до 3 лет \n" +
                              "3: От 3 до 6 лет \n" +
                              "4: Более 6 лет");
            int.TryParse(Console.ReadLine(), out experience);

            Console.WriteLine("Введите \n" +
                              "1: Высшеее образование \n" +
                              "2: Среднеее образование \n" +
                              "3: Без образования \n");
            int.TryParse(Console.ReadLine(), out education);


            Employee employee = new Employee()
            {
                Login = login,
                Password = password,
                FirstName = firstName,
                SurName = surName,
                Email = email,
                Sex = sex == "м" ? Sex.Male : sex=="ж"? Sex.Female: Sex.NoN,
                EmployeeInfo = empLoyeeInfo,
                Experience = experience == 2 ? ExperienceType.Between1And3: experience == 3 ? ExperienceType.Between3And6
                            : experience == 4 ? ExperienceType.MoreThan6 : ExperienceType.NoExperience,
                Education = education == 1 ? EducationType.HigherEducation: education == 2 
                    ? EducationType.SecondaryEducation: EducationType.WithoutEducation
            };


            Result<bool> result = _userService.RegistredUser(employee, password2);


            if (result.IsSuccess == false)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                RegistrationEmployer();
            }
            else
            {
                nameUser = login;
                Menu(EmployeeMenu);
            }
        }

        public static void AvtorizaionUsser()
        {
            AvtorizaionUsserService _avtorizaion = new AvtorizaionUsserService();
            string login, pass;
            Console.Clear();
            Console.WriteLine("Введите логин");
            login = Console.ReadLine();
            Console.WriteLine("Введите пороль");
            pass = Console.ReadLine();

            var IsRessult = _avtorizaion.Avtorizaion(login, pass);

            if (IsRessult.IsSuccess == false)
            {
                Console.WriteLine(IsRessult.Message);
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                AvtorizaionUsser();
            }
            else
            {
                nameUser = login;
                if (_avtorizaion.AvtorizaionTupe(login).Message == "Employer")
                {
                    Menu(EmployerMenu);
                }
                else
                {
                    Menu(EmployeeMenu);
                }
                
            }

        }

        public static void Menu(List<Option> options)
        {
            int index = 0;
            WriteMenu(options, options[index]);

            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (keyinfo.Key != ConsoleKey.X);

            Console.ReadKey();
        }

        /// <summary>
        /// Главное меню
        /// </summary>
        public static List<Option> mainMenu = new List<Option>
            {
                new Option("Войти", () => AvtorizaionUsser()),
                new Option("Зарегистрироваться", () => RegistrationMenu()),
                new Option("Выйти из приложения", () => Environment.Exit(0)),
            };
        
        public static void Exit()
        {
            Menu(mainMenu);
        }

        /// <summary>
        /// Меню регистрации
        /// </summary>
        public static void RegistrationMenu()
        {
            Console.Clear();
            List<Option> Registration = new List<Option>
            {
                new Option("Зарегистрироваться как Работодатель", () => RegistrationEmployer() ),
                new Option("Зарегистрироваться как Соискатель", () => RegistrationEmployee() ),
                new Option("Вернуться в главное меню", () => Exit() )
            };
            Menu(Registration);
        }

        /// <summary>
        /// Меню работодателя
        /// </summary>
        public static List<Option> EmployerMenu = new List<Option>
        {
            new Option("Регистрация вакансий", () => VacancyRegistration() ),
            new Option("Просмотреть вакансии", () => SeeVacancies()),
            new Option("Изменить доступ к вакансии", () => ChangeStatus() ),
            new Option("Вернуться в главное меню", () => Exit())
        };


        /// <summary>
        /// Меню соискателя
        /// </summary>
        public static List<Option> EmployeeMenu = new List<Option>
        {
            new Option("Просмотреть доступные вакансии", () => SeeAvailableVacancies()),
            new Option("Вернуться в главное меню", () => Exit())
        };

        /// <summary>
        /// Регистрация вакансий
        /// </summary>
        public static void VacancyRegistration()
        {
            string name, description, keyskills, address, contact;
            int experience = 1; int type = 1;
            decimal salary = 1;
            int hastest = 1;
            DateTime publishedAt = DateTime.Today;

            Console.Clear();
            Console.WriteLine("Введите название вакансии:");
            name = Console.ReadLine();
            Console.WriteLine("Введите описание вакансии:");
            description = Console.ReadLine();
            Console.WriteLine("Введите тип вакансии:\n" +
                "1: Открытая\n" +
                "2: Закрытая");
            int.TryParse(Console.ReadLine(), out type);
            Console.WriteLine("Введите необходимые ключевые умения:");
            keyskills = Console.ReadLine();
            Console.WriteLine("Введите адрес: ");
            address = Console.ReadLine();
            Console.WriteLine("Введите необходимый опыт работы\n" +
                               "1: Нет опыта \n" +
                               "2: От 1 года до 3 лет \n" +
                               "3: От 3 до 6 лет \n" +
                               "4: Более 6 лет");
            int.TryParse(Console.ReadLine(), out experience);
            Console.WriteLine("Введите оклад: ");
            decimal.TryParse(Console.ReadLine(), out salary);
            Console.WriteLine("Введите дату публикации вакансии: ");
            DateTime.TryParse(Console.ReadLine(), out publishedAt);
            Console.WriteLine("Введите контакты для связи: ");
            contact = Console.ReadLine();
            Console.WriteLine("Будет ли иметься тестовое задание:\n" +
                                "1: Да\n" +
                                "2: Нет");
            int.TryParse(Console.ReadLine(), out hastest);

            Vacancy vacancy = new Vacancy()
            {
                Name = name,
                Description = description,
                Type = type == 1 ? VacancyType.Open : VacancyType.Closed,
                KeySkills = keyskills,
                Address = address,
                Experience = experience == 1 ? ExperienceType.NoExperience
                    : experience == 2 ? ExperienceType.Between1And3
                    : experience == 3 ? ExperienceType.Between3And6
                    : ExperienceType.MoreThan6,
                Salary = salary,
                PublishedAt = publishedAt,
                Contact = contact,
                Hastest = hastest == 1 ? HasTest.Has : HasTest.HasNot
            };
        }

        /// <summary>
        /// Просмотр вакансий
        /// </summary>
        public static void SeeVacancies()
        {
            //Надо написать
        }

        /// <summary>
        /// Изменить статус вакансии
        /// </summary>
        public static void ChangeStatus()
        {
            //Надо написать 
        }

        /// <summary>
        /// Просмотр доступных вакансий для соискателя 
        /// </summary>
        public static void SeeAvailableVacancies()
        {
            //Надо написать
        }



        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();
            if (options == mainMenu)
            {
                Console.WriteLine("Вас приветствует приложение Доски Объявлений\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите дальнейшие действия\n");
                Console.ResetColor();
            }
            if(options == EmployeeMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Личный кабинет Соискателя\n");
                Console.ResetColor();
                Console.WriteLine("Добро пожаловать\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите дальнейшие действия\n");
                Console.ResetColor();
            }
            if (options == EmployerMenu)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Личный кабинет Работодателя\n");
                Console.ResetColor();
                Console.WriteLine("Добро пожаловать\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Выберите дальнейшие действия\n");
                Console.ResetColor();
            }


            foreach (Option option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(option.Name);
            }
        }
    }
}
