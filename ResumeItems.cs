using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Documents;

public class ResumeItems
{
	public List <int> Expirient { get; set; }
	public List<double> Salary { get; set; }
	public List <string> Sity { get; set; }
	public ResumeItems()
    {
        Expirient = new List<int>();
        Salary = new List<double>();
        Sity = new List<string>();
    }
}
