namespace RPN;

public class AbsoluteVal : Operator
{
    public override void Operate(MyStack<int> stack)
    {
        int num = stack.Pop();
        if (num < 0)
        {
            num *= -1;
        }
        stack.Push(num);
    }
}