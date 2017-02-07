using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace CSharpV6
{
    class Program
    {
        static void Main(string[] args)
        {
            // http://www.volatileread.com/Wiki/Index?id=1075
            Console.WriteLine("...............C# Version 6 Features.................\n");

            Console.WriteLine("1. Exception Filters");
            ExceptionFiltersClass _exceptionFiltersClass = new ExceptionFiltersClass();
            _exceptionFiltersClass.ShowExceptionFilterMethod();
            Console.WriteLine("\n");
            
            Console.WriteLine("2. Using await in catch and finally blocks");
            AwaitInCatchBlockClass _awaitInCatchBlockClass = new AwaitInCatchBlockClass();
            _awaitInCatchBlockClass.AwaitInCatchBlockMethod();
            Console.WriteLine("\n");

            Console.WriteLine("3. The nameof Operator");
            NameOfOperatorClass _nameOfOperatorClass = new NameOfOperatorClass();
            _nameOfOperatorClass.NameOfOperatorMethod();
            Console.WriteLine("\n");

            Console.WriteLine("4. Null Conditional Operator");
            NullConditionalOepratorClass _nullConditionalOepratorClass = new NullConditionalOepratorClass();
            _nullConditionalOepratorClass.NullConditionalOperatorMethod();
            Console.WriteLine("\n");

            Console.WriteLine("5. Auto Property Initializers");
            AutoPropertyInitializersClass _autoPropertyInitializersClass = new AutoPropertyInitializersClass();
            _autoPropertyInitializersClass.AutoPropertyInitializersMethod();
            Console.WriteLine("\n");

            Console.WriteLine("6. String Interpolation");
            StringInterpolationClass _stringInterpolationClass = new StringInterpolationClass();
            _stringInterpolationClass.StringInterpolationMethod();
            Console.WriteLine("\n");

            Console.WriteLine("7. using statement for static classes");
            UsingStatementForStaticClasses _usingStatementForStaticClasses = new UsingStatementForStaticClasses();
            _usingStatementForStaticClasses.UsingStatementForStaticClassesMethod();
            WriteLine("\n");
        }
    }

    // 1. Exception Filters
    // http://www.volatileread.com/Wiki/Index?id=1087
    public class ExceptionFiltersClass
    {
        public void ShowExceptionFilterMethod()
        {
            try
            {
                throw new Exception("Example 2");
            }
            catch (Exception ex) when (ex.Message == "Example 1")
            {
                Console.WriteLine("Caught Example 1");
            }
            catch(Exception ex) when (ex.Message == "Example 2")
            {
                Console.WriteLine("Caught Example 2");
            }
        }
    }

    // 2. Using await in catch and finally blocks
    public class AwaitInCatchBlockClass
    {
        public void AwaitInCatchBlockMethod()
        {
            BuggyFunctionAsync();
            Console.WriteLine("done!");
            Thread.Sleep(2000);
        }

        public async void BuggyFunctionAsync()
        {
            try { throw new Exception(); }
            catch
            {
                Console.WriteLine("entering catch block");
                await Task.Delay(1000);
                Console.WriteLine("exiting catch block");
            }
            finally
            {
                Console.WriteLine("entering finally block");
                await Task.Delay(1000);
                Console.WriteLine("exiting finally block");
            }
        }
    }

    // 3. The nameof Operator
    public class NameOfOperatorClass
    {
        public void NameOfOperatorMethod()
        {
            Console.WriteLine("The Name of Account : " + nameof(Account));
            Console.WriteLine("The Name of AccountNumber : " + nameof(Account.AccountNumber));
        }

        public class Account
        {
            public static int AccountNumber { get; set; }
        }
    }

    //4. Null Conditional Operator
    public class NullConditionalOepratorClass
    {
        public void NullConditionalOperatorMethod()
        {
            Test(null);
            Test("CAT");
            Test("Elephant");
        }

        public void Test(string msg)
        {
            Console.WriteLine(msg + ":" + msg?.Length);
        }
    }

    //5. Auto Property Initializers - http://www.volatileread.com/Wiki/Index?id=2104
    public class AutoPropertyInitializersClass
    {
        public void AutoPropertyInitializersMethod()
        {
            Account _account = new Account();
            _account.Name = "XYZ";

            Console.WriteLine("Account Name :" + _account.Name);
            Console.WriteLine("Account Number :" + _account.Number);
            Console.WriteLine("Account Routing Number :" + _account.RoutingNumber);
        }

        public class Account
        {
            public string Name { get; set; } = "Sunil Kumar";
            public int Number { get; set; } = 100;
            public int RoutingNumber { get; set; } = 200;
        }
    }

    //6. String Interpolation    
    /// <summary>
    /// Replaces String.Format
    /// </summary>
    public class StringInterpolationClass
    {
        public void StringInterpolationMethod()
        {
            var dog = "100 DOGS";
            var cat = "50 CATS";

            Console.WriteLine($"There are {dog} and {cat}");
        }
    }

    //7. "using" statement for static classes
    public class UsingStatementForStaticClasses
    {
        public void UsingStatementForStaticClassesMethod()
        {
            WriteLine("Example 1 without using Console.WriteLine");
            WriteLine("Example 2 without using Console.WriteLine");
        }

    }

}


