using Liki.Domain.Seedwork;

namespace Liki.Domain.Core.Aggregates.UserAgg
{
 
   public class UserBusinessRules
   {

       /// <summary>
       /// Define User business rules
       /// </summary>
       public static readonly BusinessRule FirstNameRequired = new BusinessRule("FirstName", "A User must have a first name.");
       public static readonly BusinessRule LastNameRequired = new BusinessRule("LastName", "A User must have a second name.");
       public static readonly BusinessRule EmailRequired = new BusinessRule("Email","A User must have a valid email address.");
    }
 
}
