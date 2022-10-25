using System.Runtime.ExceptionServices;

int divide(int a, int b)
{
    return a / b;
}

ExceptionDispatchInfo dispatchInfo = null;
try
{
    var result = divide(1, 0);
    Console.WriteLine(result);
}
catch (ArithmeticException ex)
{
    Console.WriteLine("Message = '{0}', StackTrace.Length = {1}", ex.Message, ex.StackTrace?.Length);
    dispatchInfo = ExceptionDispatchInfo.Capture(ex);
}

try
{
    dispatchInfo?.Throw();
}
catch (ArithmeticException ex)
{
    Console.WriteLine("Message = '{0}', StackTrace.Length = {1}", ex.Message, ex.StackTrace?.Length);
}

/* Output:
    Message = 'Attempted to divide by zero.', StackTrace.Length = 265
    Message = 'Attempted to divide by zero.', StackTrace.Length = 441
*/