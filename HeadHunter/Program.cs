using HeadHunter.Models;
using System;
using HeadHunter.Enums;
using HeadHunter.Services;
using HeadHunter.Utilits;
using System.Collections.Generic;
using HeadHunter.Repositories;

namespace HeadHunter
{
    internal class Program
    {
        private static string nameUser ="";
        private static int idUser = 0;
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

            string firstName ="" , surName ="", login ="", password ="", password2 ="", email ="", 
                companyName ="", description="", address ="", sex ="";
            int foundationYear = 0;

            Console.Clear();

            while (login.Trim() =="")
            {
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();
                if (login.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (password.Trim() == "" || password.Length< 6)
            {

                Console.WriteLine("\nВведите пароль, пороль должен быть не меньше 6 символов:");
                password = Console.ReadLine();
                if (password.Trim() == "" || password.Length < 6)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пороль должен быть не меньше 6 символов и не может быть пустым");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (password != password2)
            {

                Console.WriteLine("\nПовторите  пароль");
                password2 = Console.ReadLine();
                if (password != password2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пороль должен совподать");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (firstName.Trim() == "")
            {
                Console.WriteLine("\nВведите Имя:");
                firstName = Console.ReadLine();
                if (firstName.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (surName.Trim() == "")
            {
                Console.WriteLine("\nВведите Фамилию:");
                surName = Console.ReadLine();
                if (surName.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            var isSex = true;
            while (isSex)
            {
                Console.WriteLine("\nВведите Пол м или ж:");
                sex = Console.ReadLine().ToLower();

                switch (sex)
                {
                    case "м":
                        isSex = false;
                        break;
                    case "ж":
                        isSex = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Данные обезатильны");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            var isEmail = true;
            while (isEmail)
            {
                Console.WriteLine("\nВведите email:");
                email = Console.ReadLine();

                if (email.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (!email.Contains("@"))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Какой Email без @");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isEmail = false;
                }
            }


            while (companyName.Trim() == "")
            {
                Console.WriteLine("\nВведите название компании:");
                companyName = Console.ReadLine();

                if (companyName.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (description.Trim() == "")
            {
                Console.WriteLine("\nВведите описания компании:");
                description = Console.ReadLine();

                if (description.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (address.Trim() == "")
            {
                Console.WriteLine("\nВведите описания компании:");
                address = Console.ReadLine();

                if (address.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            
            yea:
            Console.WriteLine("\nВведите год основания компании:");
            if(!int.TryParse(Console.ReadLine(), out foundationYear) && foundationYear < 0)
            {
                Console.WriteLine("\nНекорректный ввод!");
                goto yea;
            }

            if (foundationYear <= 0) foundationYear = DateTime.Now.Year;

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


            Result<bool> result = _userService.RegisteredUser(employer, password2);


            if (result.IsSuccess == false)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                Menu(mainMenu);
            }
            else
            {
                AuthorizationUserService _avtorizaion = new AuthorizationUserService();
                nameUser = login;
                Menu(EmployerMenu);
                idUser = _avtorizaion.AuthorizationType(login).UserId;
                Menu(EmployerMenu);
            }
        }

        /// <summary>
        /// Регистрация Соискателя
        /// </summary>
        public static void RegistrationEmployee()
        {
            EmployeeService _userService = new EmployeeService();

            string firstName ="", surName ="", login ="", password ="", password2 ="",email ="", sex ="", empLoyeeInfo ="" ;
            int experience =1, education = 3;

            Console.Clear();
            while (login.Trim() == "")
            {
                Console.WriteLine("Введите логин:");
                login = Console.ReadLine();
                if (login.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (password.Trim() == "" || password.Length < 6)
            {

                Console.WriteLine("\nВведите пароль, пороль должен быть не меньше 6 символов:");
                password = Console.ReadLine();
                if (password.Trim() == "" || password.Length < 6)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пороль должен быть не меньше 6 символов и не может быть пустым");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            while (password != password2)
            {

                Console.WriteLine("\nПовторите  пароль");
                password2 = Console.ReadLine();
                if (password != password2)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пороль должен совподать");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (firstName.Trim() == "")
            {
                Console.WriteLine("\nВведите Имя:");
                firstName = Console.ReadLine();
                if (firstName.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            while (surName.Trim() == "")
            {
                Console.WriteLine("\nВведите Фамилию:");
                surName = Console.ReadLine();
                if (surName.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            var isSex = true;
            while (isSex)
            {
                Console.WriteLine("\nВведите Пол м или ж:");
                sex = Console.ReadLine().ToLower();

                switch (sex)
                {
                    case "м":
                        isSex = false;
                        break;
                    case "ж":
                        isSex = false;
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Данные обезатильны");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            var isEmail = true;
            while (isEmail)
            {
                Console.WriteLine("\nВведите email:");
                email = Console.ReadLine();

                if (email.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                if (!email.Contains("@"))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Какой Email без @");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    isEmail = false;
                }
            }

            while (empLoyeeInfo.Trim() == "")
            {
                Console.WriteLine("\nОпишите свои качества:");
                empLoyeeInfo = Console.ReadLine();

                if (empLoyeeInfo.Trim() == "")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Данные обезатильны");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            

            expi:
            Console.WriteLine("\nВведите ваш опыт работы: \n" +
                              "1: Нет опыта \n" +
                              "2: От 1 года до 3 лет \n" +
                              "3: От 3 до 6 лет \n" +
                              "4: Более 6 лет");
            if (!int.TryParse(Console.ReadLine(), out experience) || experience < 1 || experience > 4)
            {
                Console.WriteLine("\nНекорректный ввод!");
                goto expi;
            }
            edu:
            Console.WriteLine("\nВведите ваше образование: \n" +
                              "1: Высшеее образование \n" +
                              "2: Среднеее образование \n" +
                              "3: Без образования \n");
            if (!int.TryParse(Console.ReadLine(), out education) || education < 1 || education > 3)
            {
                Console.WriteLine("\nНекорректный ввод!");
                goto edu;
            }

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


            Result<bool> result = _userService.RegisteredUser(employee, password2);


            if (result.IsSuccess == false)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                Menu(mainMenu);
            }
            else
            {
                AuthorizationUserService _avtorizaion = new AuthorizationUserService();
                nameUser = login;
                idUser = _avtorizaion.AuthorizationType(login).UserId;
                Menu(EmployeeMenu);
            }
        }

        public static void AuthorizationUser()
        {
            AuthorizationUserService _avtorizaion = new AuthorizationUserService();
            string login, pass;
            Console.Clear();
            Console.WriteLine("Введите логин");
            login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            pass = Console.ReadLine();

            var IsRessult = _avtorizaion.Authorization(login, pass);

            if (IsRessult.IsSuccess == false)
            {
                Console.WriteLine(IsRessult.Message);
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                Menu(mainMenu);
            }
            else
            {
                
                
                if (_avtorizaion.AuthorizationType(login).Message == "Employer")
                {
                    
                    nameUser = login;
                    idUser = _avtorizaion.AuthorizationType(login).UserId;
                    Menu(EmployerMenu);
                }
                else
                {
                    
                    nameUser = login;
                    idUser = _avtorizaion.AuthorizationType(login).UserId;
                    Menu(EmployeeMenu);
                }
                
            }

        }
        /// <summary>
        /// Обнуление данных и переход в стартовое меню
        /// </summary>
        public static void LogOut()
        {
            nameUser = "";
            idUser = 0;
            Console.Clear();
            Menu(mainMenu);
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
                new Option("Войти", () => AuthorizationUser()),
                new Option("Зарегистрироваться", () => RegistrationMenu()),
                new Option("Выйти из приложения", () => Environment.Exit(0)),
            };

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
                new Option("Вернуться в главное меню", () => LogOut() )
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
            new Option("Вернуться в главное меню", () => LogOut())
        };


        /// <summary>
        /// Меню соискателя
        /// </summary>
        public static List<Option> EmployeeMenu = new List<Option>
        {
            new Option("Просмотреть доступные вакансии", () => SeeAvailableVacancies()),
            new Option("Вернуться в главное меню", () => LogOut())
        };

        /// <summary>
        /// Регистрация вакансий
        /// </summary>
        public static void VacancyRegistration()
        {
            VacancyService _vacancyService = new VacancyService();
            string name, description, keyskills, address, contact;
            int experience = 1; int type = 1;
            decimal salary = 1;
            int hastest = 1;
            DateTime publishedAt = DateTime.Today;

            Console.Clear();
            Console.WriteLine("Введите название вакансии:");
            name = Console.ReadLine();
            Console.WriteLine("\nВведите описание вакансии:");
            description = Console.ReadLine();

            ty:
            Console.WriteLine("\nВведите тип вакансии:\n" +
                "1: Открытая\n" +
                "2: Закрытая");
            if(!int.TryParse(Console.ReadLine(), out type) && type < 1 && type > 2)
            {
                Console.WriteLine("\nНекорректный ввод!");
                goto ty;
            }
            Console.WriteLine("\nВведите необходимые ключевые умения:");
            keyskills = Console.ReadLine();
            Console.WriteLine("\nВведите адрес: ");
            address = Console.ReadLine();

            ex:
            Console.WriteLine("\nВведите необходимый опыт работы\n" +
                               "1: Нет опыта \n" +
                               "2: От 1 года до 3 лет \n" +
                               "3: От 3 до 6 лет \n" +
                               "4: Более 6 лет");
            if(!int.TryParse(Console.ReadLine(), out experience) && experience < 1 && experience > 4)
            {
                Console.WriteLine("\nНекорректный ввод!");
                goto ex;
            }
            Console.WriteLine("\nВведите оклад: ");
            decimal.TryParse(Console.ReadLine(), out salary);

            d:
            Console.WriteLine("\nВведите дату публикации вакансии (ГГГГ,ММ,ДД): ");
            if(!DateTime.TryParse(Console.ReadLine(), out publishedAt))
            {
                Console.WriteLine("\nНекорректный ввод!");
                goto d;
            }
            Console.WriteLine("\nВведите контакты для связи: ");
            contact = Console.ReadLine();

            l:
            Console.WriteLine("\nБудет ли иметься тестовое задание:\n" +
                                "1: Да\n" +
                                "2: Нет");
            if(!int.TryParse(Console.ReadLine(), out hastest) && hastest < 1 && hastest > 2)
            {
                Console.WriteLine("\nНекорректный ввод!");
                goto l;
            }

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
                Hastest = hastest == 1 ? HasTest.Has : HasTest.HasNot,
                EmpId = idUser
            };
            Result<bool> result = _vacancyService.RegisteredVacancy(vacancy);

            if (result.IsSuccess == false)
            {
                Console.WriteLine(result.Message);
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                Menu(EmployerMenu);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вакансия успешно добавлена!\n");
                Console.ResetColor();
                Console.WriteLine("Нажмите любую кнопку что бы продолжить");
                Console.ReadKey();
                Menu(EmployerMenu);
            }

        }

        /// <summary>
        /// Просмотр вакансий
        /// </summary>
        public static void SeeVacancies()
        {
            Console.Clear();
            VacanciesRepository _vacanciesRepository = new VacanciesRepository();
            var vacancies = _vacanciesRepository.GetVacancy(idUser);
            foreach (var item in vacancies)
            {
                item.PrintInfo();
            }

            Console.WriteLine("\nНажмите на любую клавишу чтобы вернуться назад");
            Console.ReadKey();
            Menu(EmployerMenu);
        }

        /// <summary>
        /// Изменить статус вакансии
        /// </summary>
        public static void ChangeStatus()
        {
            Console.Clear();
            int vacancyId, status;
            VacancyType option;
            iv:
            Console.WriteLine("Введите идентификационный номер вакансии: ");
            if (!int.TryParse(Console.ReadLine(), out vacancyId) && vacancyId > 0 )
            {
                Console.WriteLine("Некорректный ввод!");
                goto iv;
            }
            
            st:
            Console.WriteLine("Выберите какой статус вы хотите присвоить вакансии:\n" +
                                "1: Открытый\n" +
                                "2: Закрытый");
            if (!int.TryParse(Console.ReadLine(), out status) && status < 1 && status > 2)
            {
                Console.WriteLine("Некорректный ввод!");
                goto st;
            }
            
            if(status == 1)
            {
                option = VacancyType.Open;
            }
            else
            {
                option = VacancyType.Closed;
            }
            VacanciesRepository _vacanciesRepository = new VacanciesRepository();
            _vacanciesRepository.ChangeVacancyType(vacancyId, option);

            Console.WriteLine("\nНажмите на любую клавишу чтобы вернуться назад");
            Console.ReadKey();
            Menu(EmployerMenu);
        }

        /// <summary>
        /// Просмотр доступных вакансий для соискателя 
        /// </summary>
        public static void SeeAvailableVacancies()
        {
            VacanciesRepository _vacanciesRepository = new VacanciesRepository();

            var Vacancies = _vacanciesRepository.GetVacancyOpen();

            foreach (var item in Vacancies)
            {
                item.PrintInfo();
            }
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
                Console.WriteLine($"Добро пожаловать {nameUser}\n");
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
                Console.WriteLine($"Добро пожаловать {nameUser}\n");
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
