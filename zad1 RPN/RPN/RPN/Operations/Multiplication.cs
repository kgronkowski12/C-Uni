namespace RPN;

public class Multiplication : Operator
{
    public override void Operate(MyStack<int> stack)
    {
        int num1 = stack.Pop();
        int num2 = stack.Pop();
        int num3 = num1 * num2;
        stack.Push(num3);
    }
}
