using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace RPN;

public class Rpn
{
    private readonly MyStack<int> _operators= new MyStack<int>();
    private readonly Dictionary<string, Operator> _operationFunction = new Dictionary<string, Operator>();
    private readonly NumberExtractor numberExtractor = new NumberExtractor();
    public int EvalRpn(string input)
    {
        _operationFunction["+"] = new Addition();
        _operationFunction["-"] = new Subtraction();
        _operationFunction["*"] = new Multiplication();
        _operationFunction["/"] = new Division();
        _operationFunction["!"] = new Factorial();
        _operationFunction["|"] = new AbsoluteVal();

        var splitInput = input.Split(' ');
        foreach (var op in splitInput)
        {
            if (IsOperator(op))
            {
                _operationFunction[op].Operate(_operators);
            }
            else
            {
                _operators.Push(numberExtractor.GetNumber(op));
            }
        }

        var result = _operators.Pop();
        if (_operators.IsEmpty)
        {
            return result;
        }
        throw new InvalidOperationException();
    }
    private bool IsOperator(String input)
    {
        return _operationFunction.ContainsKey(input);
    }
}