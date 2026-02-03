using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    
    internal class Program1
    {   
        public Program1(int bal,string empname, int sal)
        {
            
            this.bal = bal;
            this.empname = empname;
            this.sal = sal;
        }
        private decimal bal;
        public decimal Bal
        {
            get { return bal; }//getting a value
            set { bal = value; }//setting a value
        }
        private string empname;
        public string EmpName 
            { get { return empname; }
             set {  
                if(value.Length > 10)
                {
                    throw new ApplicationException("exceeded");
                }
                else
                {
                    empname = value;
                }
            }
            }
        private decimal sal;
        public decimal Sal
        {
            get { return sal; }//getting a value
            set { sal = value; }//setting a value
        }


        public override string ToString()
        {
            return $"EmpName : {empname} , Salary : {sal} , Balance : {bal}";

        }

    }

}
