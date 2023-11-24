using System;

// Базовый класс "Employee"
class Employee
{
    protected string name;
    protected int age;
    protected double salary;

    public Employee(string name, int age, double salary)
    {
        this.name = name;
        this.age = age;
        this.salary = salary;
    }
    // Метод для получения информации о сотруднике
    public virtual void GetInfo()
    {
        Console.WriteLine($"Name: {name}\nAge: {age}\nSalary: {salary:C}");
    }

    // Метод для расчета годовой зарплаты
    public virtual double CalculatepeterSalary()
    {
        return salary * 12;
    }
}

// Класс "Manager", наследуется от "Employee"
class Manager : Employee
{
    // Дополнительное поле для бонуса
    private double bonus;

    // Конструктор для инициализации полей базового и производного классов
    public Manager(string name, int age, double salary, double bonus) : base(name, age, salary)
    {
        this.bonus = bonus;
    }

    // Переопределенный метод для расчета годовой зарплаты с учетом бонуса
    public override double CalculatepeterSalary()
    {
        // Предполагаем, что зарплата указана в месяц
        double baseSalary = base.CalculatepeterSalary();
        return baseSalary + bonus;
    }
}

// Класс "Developer", наследуется от "Employee"
class Developer : Employee
{
    private int linesOfCodePerDay;

    public Developer(string name, int age, double salary, int linesOfCodePerDay) : base(name, age, salary)
    {
        this.linesOfCodePerDay = linesOfCodePerDay;
    }

    // Переопределенный метод для расчета годовой зарплаты с учетом оплаты за строки кода
    public override double CalculatepeterSalary()
    {
        // Предполагаем, что зарплата указана в месяц
        double baseSalary = base.CalculatepeterSalary();

        // Предполагаем, что за каждую строку кода дается определенная дополнительная оплата
        double additionalPaymentPerLineOfCode = 0.10; // Пример дополнительной оплаты за строку кода
        double linesOfCodeBonus = linesOfCodePerDay * additionalPaymentPerLineOfCode * 250; // Предполагаем 250 рабочих дней в году

        return baseSalary + linesOfCodeBonus;
    }
}

class Program
{
    static void Main()
    {
        // Создание экземпляра класса Manager
        Manager manager = new Manager("John Peter", 35, 6000, 2000);

        // Вывод информации о менеджере
        Console.WriteLine("Manager's Information:");
        manager.GetInfo();

        // Расчет и вывод годовой зарплаты с учетом бонуса
        double peterSalaryWithBonus = manager.CalculatepeterSalary();
        Console.WriteLine($"Peter Salary with Bonus: {peterSalaryWithBonus:C}");

        Console.WriteLine("\n-----------------------------\n");

        // Создание экземпляра класса Developer
        Developer developer = new Developer("Bob Johnson", 28, 5500, 100);

        // Вывод информации о разработчике
        Console.WriteLine("Developer's Information:");
        developer.GetInfo();

        // Расчет и вывод годовой зарплаты с учетом оплаты за строки кода
        double peterSalaryWithCodeBonus = developer.CalculatepeterSalary();
        Console.WriteLine($"Peter Salary with Code Bonus: {peterSalaryWithCodeBonus:C}");
    }
}

