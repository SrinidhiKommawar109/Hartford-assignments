

using OOPS_2;

public class SalaryThenDeptwiseComparer : IComparer<Emp>
{
    public int Compare(Emp? x, Emp? y)
    {
        // 1. Compare Salary first
        int salaryResult = x.EmpSalary.CompareTo(y.EmpSalary);

        // 2. If salary is same, compare Department
        if (salaryResult == 0)
        {
            return x.EmpDept.CompareTo(y.EmpDept);
        }

        return salaryResult;
    }
}
