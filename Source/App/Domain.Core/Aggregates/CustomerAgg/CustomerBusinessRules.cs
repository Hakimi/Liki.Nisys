using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.CustomerAgg
{
 
   public class CustomerBusinessRules
   {

       /// <summary>
       /// Define Customer business rules
       /// </summary>
       public static readonly BusinessRule FirstNameRequired = new BusinessRule("FirstName", "A customer must have a first name.");
       public static readonly BusinessRule LastNameRequired = new BusinessRule("LastName", "A customer must have a second name.");
       public static readonly BusinessRule EmailRequired = new BusinessRule("Email","A customer must have a valid email address.");
    }
 
}
