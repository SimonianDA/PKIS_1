using Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling;
using Programming_of_corporate_industrial_systems_Practice_1.ErrorHandling.ErrorsTypes;
using System;

public class ErrorHandler : IErrorHandler
{
    private const string _systemErrorMessage = "Ошибка системы";

    public void ExecuteWithErrorHandling(Action action)
    {
        try
        {
            action();
        }
        catch (CommonException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (Exception)
        {
            Console.WriteLine(_systemErrorMessage);
        }
    }
}