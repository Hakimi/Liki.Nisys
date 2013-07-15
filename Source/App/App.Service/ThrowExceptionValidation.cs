using System;
using System.Linq;
using System.Text;
using Liki.Domain.Seedwork;

namespace Liki.App.Service
{
   public class ThrowExceptionValidation <TEntity>  where  TEntity : Entity
   {
       #region Constructors
       public ThrowExceptionValidation()
       {
           
       }
       #endregion
       #region Method
       /// <summary>
       /// validation check 
       /// </summary>
       /// <param name="item"></param>
       public void ThrowExceptionIfCustomerIsInvalid(TEntity item)
       {
           if (item != (TEntity)null)
           {
               if (item.GetBrokenRules().Any())
               {
                   var brokenRules = new StringBuilder();
                   brokenRules.AppendLine("There were problems saving the Customer:");
                   foreach (BusinessRule businessRule in item.GetBrokenRules())
                   {
                       brokenRules.AppendLine(businessRule.Rule);
                   }
                   throw new Exception(brokenRules.ToString());
               }
           }
       }
       #endregion
    }
}
