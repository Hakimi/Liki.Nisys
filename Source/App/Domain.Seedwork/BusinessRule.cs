namespace Liki.Domain.Seedwork
{
   public class BusinessRule
   {
       #region Members
       private string _property;
       private string _rule;
       #endregion

       #region Constructors
       public BusinessRule(string property, string rule)
       {
           this._property = property;
           this._rule = rule;
       }

       #endregion

       #region Property
       public string Property
       {
           get { return _property; }
           set { _property = value; }
       }

       public string Rule
       {
           get { return _rule; }
           set { _rule = value; }
       }   
       #endregion

           
    }
}
