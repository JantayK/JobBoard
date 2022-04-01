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
            sex = Console.ReadLine();
            Console.WriteLine("Введите email:");
            email = Console.ReadLine();
            Console.WriteLine("Введите название компании:");
            companyName = Console.ReadLine();
            Console.WriteLine("Введите описания компании:");
            description = Console.ReadLine();
            Console.WriteLine("Введите адрес компании:");
            address = Console.ReadLine();
            Console.WriteLine("Введите год основания компании:");
           int.TryParse(Console.ReadLine(), out foundationYear);


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
                Sex = sex == "м" ? Sex.Male: Sex.Female,
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
                //Вызываем меню работадателя 
            }
        }

        /// <summary>
        /// Регистрация Соискателя
        /// </summary>
        public static void RegistrationEmployee()
        {
            EmployeeServes _userService = new EmployeeServes();
          
            string firstName, surName, login, password, password2,email, sex;

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
            sex = Console.ReadLine();
            


            Employee employee = new Employee()
           {
                Login = login,
                Password = password,
                FirstName = firstName,
                SurName = surName,
                Email = email,
                Sex = sex == "м" ? Sex.Male : Sex.Female,
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
                //Вызываем меню работника
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
                    //Вызываем меню работадателя 
                }
                else
                {
                    //Вызываем меню работника
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
        
        static void WriteMenu(List<Option> options, Option selectedOption)
        {
            Console.Clear();
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

        /// <summary>
        /// Главное меню
        /// </summary>
        public static List<Option> mainMenu = new List<Option>
            {
                new Option("Войти", () => AvtorizaionUsser()),
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
                new Option("Зарегистрироваться как Соискатель", () => RegistrationEmployee() )
            };
            Menu(Registration);
        }
        /// <summary>
        /// Регистрация вакансий
        /// </summary>
        public static void VacancyRegistration()
        {
            string name, description, keyskills, address, contact;
            int experience; int type;
            decimal salary;
            int hastest ;
            DateTime publishedAt = DateTime.Today;

            Console.Clear();
            Console.WriteLine("Введите название вакансии:");
            name = Console.ReadLine();
            Console.WriteLine("Введите описание вакансии:");
            description = Console.ReadLine();
            Console.WriteLine("Введите тип вакансии:");
            int.TryParse(Console.ReadLine(), out type);
            Console.WriteLine("Введите  ключевые умения:");
            keyskills = Console.ReadLine();
            Console.WriteLine("Введите адрес: ");
            address = Console.ReadLine();
            Console.WriteLine("Введите опыт работы");
            int.TryParse(Console.ReadLine(), out experience);
            Console.WriteLine("Введите зарплату сотрудника: ");
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
              
            };
        }

        










    }
        
    }
}
