using System;

namespace Pecunia.Entities
{
    public enum LoanType
    {
        EDULOAN = 0, HOMELOAN = 1, CARLOAN = 2
    }
    public enum LoanStatus
    {
        APPLIED, PROCESSING, REJECTED, APPROVED
    }

    public enum ServiceType
    {
        AGRICULTURE, BUSINESS, OTHERS, RETIRED, SELF_EMPLOYED, SERVICE
    }

    public enum VehicleType
    {
        TWO_WHEELER, FOUR_WHEELER, MULTI_AXLE
    }

    public enum CourseType
    {
        UNDERGRADUATE, MASTERS, PHD, M_PHIL 
    }
    public interface ILoanEntities
    {
        string LoanID { get; set; }
        string CustomerID { get; set; }
        double AmountApplied { get; set; }
        double InterestRate { get; set; }
        double EMI_Amount { get; set; }
        int RepaymentPeriod { get; set; }
        DateTime DateOfApplication { get; set; }
        LoanStatus Status { get; set; }
        
    }

    public abstract class LoanEntities : ILoanEntities
    {
        public string LoanID { get; set; }
        public string CustomerID { get; set; }
        public double AmountApplied { get; set; }
        public double InterestRate { get; set; }
        public double EMI_Amount { get; set; }
        public int RepaymentPeriod { get; set; }
        public DateTime DateOfApplication { get; set; }
        public LoanStatus Status { get; set; }
        
    }

    public class HomeLoan : LoanEntities
    {
        public ServiceType Occupation { get; set; }
        public int ServiceYears { get; set; }
        public double GrossIncome { get; set; }
        public double SalaryDeductions { get; set; }

        
    }

    public class EduLoan : LoanEntities
    {
        public CourseType Course { get; set; }
        public int CourseDuration {get; set;}
        public string InstituteName { get; set; }
        public string StudentID { get; set; }
        public int RepaymentHoliday { get; set; }
    }

    public class CarLoan : LoanEntities
    {
        public ServiceType Occupation { get; set; }
        public double GrossIncome { get; set; }
        public double SalaryDeductions { get; set; }
        public VehicleType Vehicle { get; set; }
    }
}
