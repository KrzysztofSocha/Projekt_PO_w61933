using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_PO_w61933
{
    public class OperationsUser
    {
        public string nameOperation;
        public string valueOperation;
        private void addOperationToFile(int id, string fileName)
        {
            string operationsUser = File.ReadLines(fileName).Skip(id - 1).Take(1).First();
            string oldOperationsUser = operationsUser;
            operationsUser += this.nameOperation + " " +this.valueOperation+";";
            string operationstxt = File.ReadAllText(fileName);
           
            operationstxt = operationstxt.Replace(oldOperationsUser, operationsUser);
            
            File.WriteAllText(fileName, operationstxt);
        }
        public OperationsUser(string nameOperation, string valueOperation, int id)
        {
            this.nameOperation = nameOperation;
            this.valueOperation = valueOperation;
            addOperationToFile(id, "Operations.txt");
        }
    }
}
