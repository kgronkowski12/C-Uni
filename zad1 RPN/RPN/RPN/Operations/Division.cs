namespace RPN;

public class Division : Operator
{
    public override void Operate(MyStack<int> stack)
    {
        int num1 = stack.Pop();
        int num2 = stack.Pop();
        if (num2 == 0)
        {
            throw new InvalidOperationException();
        }
        int num3 = num1 / num2;
        stack.Push(num3);
    }
}