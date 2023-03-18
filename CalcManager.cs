using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class CalcManager
    {
        // Class for doing the math

        // Delegate for the math operations
        public delegate double MathOperation(double x, double y);

        // Dictionary for the math operations
        private Dictionary<Operation, MathOperation> operations = new Dictionary<Operation, MathOperation>();

        public MathOperation Add { get; private set; }
        public MathOperation Subtract { get; private set; }
        public MathOperation Multiply { get; private set; }
        public MathOperation Divide { get; private set; }
        public MathOperation Power { get; private set; }
        
        // Constructor
        public CalcManager()
        {
            // Add the math operations to the dictionary
            operations.Add(Operation.Add, (x, y) => x + y);
            operations.Add(Operation.Subtract, (x, y) => x - y);
            operations.Add(Operation.Multiply, (x, y) => x * y);
            operations.Add(Operation.Divide, (x, y) => x / y);
            operations.Add(Operation.Power, (x, y) => Math.Pow(x, y));
        }

        // Method for doing the math
        public double DoMath(double x, double y, Operation operation)
        {
            // Return the result of the math operation
            return operations[operation](x, y);
        }
        
    }
}
