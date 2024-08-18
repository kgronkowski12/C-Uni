namespace RPN;

public class Factorial : Operator
{
    public override void Operate(MyStack<int> stack)
    {
        int num = stack.Pop();
        int fact = 1;
        for (int i=1; i<=num; i++)
        {
            fact *= i;
        }
        stack.Push(fact);
    }
}