using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    interface IOperation { }
    interface IBinarryOperation : IOperation
    {
        int Calculate(int a, int b);
    }

    interface IUnaryOperation : IOperation
    {
        int Calculate(int a);
    }

    class AndOperation : IBinarryOperation
    {
        public int Calculate(int a, int b)
        {
            return a & b;
        }
    }

    class OrOperation : IBinarryOperation
    {
        public int Calculate(int a, int b)
        {
            return a | b;
        }
    }

    class NotOperation : IUnaryOperation
    {
        public int Calculate(int a)
        {
            return ~a;
        }
    }

    static class Calculator
    {
        private static IOperation operation = null;
        private static int? operand1 = null;
        private static int? operand2 = null;
        
        public static int SetOperation(IOperation operation)
        {
            if (operand1 == null)
            {
                throw new InvalidOperationException("First operand is not set");
            }
            else if(operation is IUnaryOperation)
            {
                Calculator.operation = operation;
                return Calculator.Calculate();
            }
            else
            {
                Calculator.operation = operation;
            }
            
            return 0;
        }

        public static void SetOperand1(int? operand1) => Calculator.operand1 = operand1;

        public static void SetOperand2(int? operand2) => Calculator.operand2 = operand2;

        public static int Calculate()
        {
            if(operation is IUnaryOperation uop)
            {
                return uop.Calculate(operand1.Value);
            }

            else if (operation is IBinarryOperation bop)
            {
                return bop.Calculate(operand1.Value, operand2.Value);
            }

            return 0;
        }
    }
}
